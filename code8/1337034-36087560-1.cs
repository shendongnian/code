    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    
    namespace WpfApplication33
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    
        public class VM
        {
            public List<OptionA> Items { get; set; }
            public VM()
            {
                Items = new List<OptionA>() {
                    new OptionA() {value=1, low_lim = 0, high_lim = 2 },
                    new OptionA() {value=2, low_lim = 3, high_lim = 4 }, // too low
                    new OptionA() {value=3, low_lim = 2, high_lim = 5 },
                    new OptionA() {value=4, low_lim = 6, high_lim = 9 }, // too low
                    new OptionA() {value=5, low_lim = 0, high_lim = 4 }, // too high
                };
            }
        }
    
        public class OptionA : INotifyPropertyChanged, IDataErrorInfo
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void OPC(string name) { if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name)); }
    
            private int _value, _low_lim, _high_lim;
            public int value { get { return _value; } set { if (_value != value) { _value = value; OPC("value"); } } }
            public int low_lim { get { return _low_lim; } set { if (_low_lim != value) { _low_lim = value; OPC("low_lim"); } } }
            public int high_lim { get { return _high_lim; } set { if (_high_lim != value) { _high_lim = value; OPC("high_lim"); } } }
    
            #region IDataErrorInfo
            public string Error
            {
                get
                {
                    return null;
                }
            }
    
            public string this[string columnName]
            {
                get
                {
                    string err = null;
                    if (columnName == "value")
                    {
                        if (value < low_lim || value > high_lim)
                            err = string.Format("Value is out of the range of {0} to {1}.", low_lim, high_lim);
                    }
                    return err;
                }
            }
            #endregion
        }
    }
