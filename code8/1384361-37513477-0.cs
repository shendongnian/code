    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication4
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var collection =
                    new SettingCollection(new Setting[]
                    {
                        new Setting<bool> {Name = "boolean"},
                        new Setting<string> {Name = "string"}
                    });
                DataContext = collection;
            }
    
            private void Button1_Click(object sender, RoutedEventArgs e)
            {
                var collection = (SettingCollection) DataContext;
                var setting = collection.OfType<Setting<bool>>().FirstOrDefault();
                if (setting != null)
                {
                    setting.Value = !setting.Value;
                }
            }
    
            private void Button2_Click(object sender, RoutedEventArgs e)
            {
                var collection = (SettingCollection) DataContext;
                var setting = collection.OfType<Setting<string>>().FirstOrDefault();
                if (setting != null)
                {
                    setting.Value = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }
            }
    
            private void Button3_Click(object sender, RoutedEventArgs e)
            {
                var collection = (SettingCollection) DataContext;
                Debugger.Break();
            }
        }
    
        public sealed class SettingCollection : ObservableCollection<Setting>
        {
            public SettingCollection(List<Setting> list) : base(list)
            {
            }
    
            public SettingCollection(IEnumerable<Setting> collection) : base(collection)
            {
            }
    
            public SettingCollection()
            {
            }
        }
    
        public abstract class Setting : INotifyPropertyChanged
        {
            private object _value;
            public string Name { get; set; }
    
            public object Value
            {
                get { return _value; }
                set
                {
                    if (Equals(value, _value)) return;
                    _value = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public sealed class Setting<T> : Setting
        {
            private T _value;
    
            public new T Value
            {
                get { return _value; }
                set
                {
                    if (Equals(value, _value)) return;
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }
    
        public class SettingTemplateSelector : DataTemplateSelector
        {
            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                var element = container as FrameworkElement;
                if (element != null && item != null)
                {
                    var type = item.GetType();
                    var types = type.GenericTypeArguments;
                    var type1 = types[0];
                    if (type1 == typeof(bool))
                    {
                        var findResource = element.FindResource("SettingBoolTemplate");
                        var dataTemplate = findResource as DataTemplate;
                        return dataTemplate;
                    }
                    if (type1 == typeof(string))
                    {
                        var findResource = element.FindResource("SettingStringTemplate");
                        var dataTemplate = findResource as DataTemplate;
                        return dataTemplate;
                    }
                }
                return null;
            }
        }
    }
