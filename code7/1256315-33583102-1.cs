    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    
    namespace WpfCommands
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new TestViewModel();
            }
        }
    
        public enum TestEnum
        {
            State1,
            State2,
        }
    
        public class TestViewModel : INotifyPropertyChanged
        {
            private TestEnum _someProperty;
    
            public TestEnum SomeProperty
            {
                get { return _someProperty; }
                set
                {
                    if (_someProperty != value)
                    {
                        _someProperty = value;
                        OnPropertyChanged("SomeProperty");
                    }
                }
            }
    
            public Command SomeCommand { get; private set; }
    
            public TestViewModel()
            {
                _someProperty = TestEnum.State2;
                SomeCommand = new Command(SomeCommand_Execute);
            }
    
            private void SomeCommand_Execute(object obj)
            {
                SomeProperty = SomeProperty == TestEnum.State1 ? TestEnum.State2 : TestEnum.State1;
                System.Diagnostics.Debug.WriteLine("------------- executed ---------------");
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string propname)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }
    
        public class Command : ICommand
        {
            public delegate void CommandExecuteHandler(object obj);
            CommandExecuteHandler handler;
    
            public Command(CommandExecuteHandler callback)
            {
                handler = callback;
            }
    
            public bool CanExecute(object parameter)
            {
                return true;
            }
    
            public event EventHandler CanExecuteChanged;
    
            public void Execute(object parameter)
            {
                handler(parameter);
            }
        }
    }
