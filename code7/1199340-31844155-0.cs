    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        using System.ComponentModel;
        using System.Runtime.CompilerServices;
        class Program
        {
            static void Main(string[] args)
            {
                // create instance
                var settings = new AppSettings();
                // subscribe for the event as soon as you can
                settings.PropertyChanged += (s, e) => Console.WriteLine("Property {0} has changed", e.PropertyName);
                Console.WriteLine("Press any key to start test");
                Console.ReadKey();
                // change the value
                settings.ComboBoxSettings = 10;
                Console.ReadKey();
            }
        }
        class AppSettings : INotifyPropertyChanged
        {
        
            private int _comboBoxSettings;
            public event PropertyChangedEventHandler PropertyChanged;
            public int ComboBoxSettings
            {
                get
                {
                    return _comboBoxSettings;
                }
                set
                {
                    _comboBoxSettings = value;
                    NotifyPropertyChanged();
                }
            }
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        #endregion
    }
