    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    namespace WPFCentralOffice.UserControls
    {
        public class Element : IEquatable<Element>
        {
            public int ID { get; set; }
            public string Caption { get; set; }
            public bool Equals(Element other)
            {
                return ID == other.ID;
            }
            public override string ToString()
            {
                return ID + " " + Caption;
            }
        }
        public class ComboBoxBindingSource : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public ComboBoxBindingSource(Element selectedElement, IEnumerable<Element> availableElements)
            {
                _selectedElement = selectedElement;
                AvailableElements = availableElements;
            }
            private Element _selectedElement;
            public Element SelectedElement
            {
                get { return _selectedElement; }
                set
                {
                    _selectedElement = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("SelectedElement"));
                    }
                }
            }
            private IEnumerable<Element> _availableElements;
            public IEnumerable<Element> AvailableElements
            {
                get { return _availableElements; }
                set
                {
                    _availableElements = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("AvailableElements"));
                    }
                }
            }
        }
        public partial class MultiSelectListUserControl : UserControl
        {
            public IEnumerable<Element> ChosenItems
            {
                get { return ComboBoxBindingSources.Select(x => x.SelectedElement); }
            }
            public ObservableCollection<Element> AllItems
            {
                get { return (ObservableCollection<Element>)GetValue(AllItemsProperty); }
                set { SetValue(AllItemsProperty, value); }
            }
            // ReSharper disable once InconsistentNaming
            public ObservableCollection<ComboBoxBindingSource> ComboBoxBindingSources
            {
                get { return (ObservableCollection<ComboBoxBindingSource>)GetValue(ComboBoxBindingSourcesProperty); }
                set { SetValue(ComboBoxBindingSourcesProperty, value); }
            }
            public static DependencyProperty AllItemsProperty = DependencyProperty.Register(
                "AllItems",
                typeof(ObservableCollection<Element>),
                typeof(MultiSelectListUserControl),
                new FrameworkPropertyMetadata(OnAllItemsChanged));
            private static void OnAllItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ((MultiSelectListUserControl)d).CoerceValue(ComboBoxBindingSourcesProperty);
            }
            public static DependencyProperty ComboBoxBindingSourcesProperty = DependencyProperty.Register(
                "ComboBoxBindingSources",
                typeof(ObservableCollection<ComboBoxBindingSource>),
                typeof(MultiSelectListUserControl));
            public void NewButton_Pressed(object sender, RoutedEventArgs e)
            {
                if (!AllItems.Any() || AllItems.Count == ComboBoxBindingSources.Count)
                {
                    return;
                }
                var remainingItems = AllItems.Where(x => ChosenItems.All(y => x.ID != y.ID)).ToList();
                ComboBoxBindingSources.Add(new ComboBoxBindingSource(remainingItems.First(), remainingItems));
                RefreshAvailableItems();
            }
            public void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
            {
                RefreshAvailableItems();
            }
            private void RefreshAvailableItems()
            {
                foreach (var source in ComboBoxBindingSources)
                {
                    var newAvailables =
                        AllItems.Where(
                            x => source.SelectedElement == x || ComboBoxBindingSources.All(y => y.SelectedElement != x));
                    source.AvailableElements = newAvailables;
                }
            }
            public MultiSelectListUserControl()
            {
                InitializeComponent();
                SetValue(AllItemsProperty, new ObservableCollection<Element>());
                SetValue(ComboBoxBindingSourcesProperty, new ObservableCollection<ComboBoxBindingSource>());
            }
        }
    }
