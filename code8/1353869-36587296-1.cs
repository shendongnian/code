    using System;
    using System.Linq;
    using Xamarin.Forms;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;
    namespace FormsSandbox
    {
        public partial class XamlPage : ContentPage
        {
            public XamlPage ()
            {
                InitializeComponent ();
                var vm = new ViewModel ();
                vm.Items.Add ("Lorem ipsum");
                vm.Items.Add ("Foo");
                vm.Items.Add ("Dolor semet");
                vm.Items.Add ("Test");
                vm.Items.Add (".");
                vm.Items.Add ("Xamarin Forms Is Great");
                vm.Items.Add ("Short");
                vm.Items.Add ("Longer than Short");
                vm.Items.Add ("");
                vm.Items.Add ("Hyphenated");
                vm.Items.Add ("Non-hyphenated");
                vm.Items.Add ("Ironic, eh?");
                BindingContext = vm;
            }
        }
        public class ViewModel : INotifyPropertyChanged
        {
            double _width;
            double _pixelsPerChar;
            public ObservableCollection<string> Items { get; private set; }
            public double Width { 
                get {
                    return _width;
                }
                set {
                    if (Math.Abs (_width - value) > 0.1) {
                        _width = value;
                        NotifyPropertyChanged ();
                    }
                }
            }
            public double PixelsPerChar { 
                get {
                    return _pixelsPerChar;
                }
                set {
                    if (Math.Abs (_pixelsPerChar - value) > 0.1) {
                        _pixelsPerChar = value;
                        NotifyPropertyChanged ();
                        Recompute ();
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            void NotifyPropertyChanged ([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null) {
                    handler (this, new PropertyChangedEventArgs (propertyName));
                }
            }
            public ViewModel() {
                Items = new ObservableCollection<string> ();
                Width = 0;
                PixelsPerChar = 9.0;
                Items.CollectionChanged += (sender, e) => Recompute();
            }
            void Recompute()
            {
                if (Items.Count > 0) {
                    Width = Items.Max (s => s.Length * PixelsPerChar);
                } else {
                    Width = 0.0;
                }
            }
        }
    }
