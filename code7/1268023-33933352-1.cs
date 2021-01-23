    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    
    namespace SimpleRibbonWinodw
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
                PropertyChanged += HandlePropertyChangedEvent;
            }
    
            private void HandlePropertyChangedEvent(object sender, PropertyChangedEventArgs e)
            {
                if (string.Equals(e.PropertyName, nameof(SomeValueText), StringComparison.InvariantCultureIgnoreCase))
                {
                    double result;
                    if (Double.TryParse(SomeValueText, out result))
                    {
                        // Do not allow property changed event
                        if (SomeValue != result)
                        {
                            SomeValue = result;
                            Debug.WriteLine($"New value of SomeValue = {SomeValue}");
                        }
                    }
                }
    
                if (string.Equals(e.PropertyName, nameof(SomeValue), StringComparison.InvariantCultureIgnoreCase))
                {
                    double result;
                    if (Double.TryParse(SomeValueText, out result))
                    {
                        if (result != SomeValue)
                        {
                            SomeValueText = SomeValue.ToString();
                            Debug.WriteLine($"New value of SomeValueText = {SomeValueText}");
                        }
                    }
                    else
                    {
                        SomeValueText = SomeValue.ToString();
                        Debug.WriteLine($"New value of SomeValueText = {SomeValueText}");
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public double SomeValue
            {
                get { return _someValue; }
                set
                {
                    _someValue = value;
                    Debug.WriteLine($"SomeValue Changed: {_someValue}");
                    RaisePropertyChangedEvent(nameof(SomeValue));
                }
            }
    
            private double _someValue;
    
            public string SomeValueText
            {
                get { return _someValueText;  }
                set
                {
                    _someValueText = value;
                    RaisePropertyChangedEvent(nameof(SomeValueText));
                }
            }
    
            private string _someValueText;
    
            protected void RaisePropertyChangedEvent(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
