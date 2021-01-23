    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    
    namespace App10
    {
        public class ViewModel : INotifyPropertyChanged
        {
            private bool _isChecked;
    
            // property for TwoWay binding with ToggleButton
            public bool IsChecked
            {
                get
                {
                    return _isChecked;
                }
                set
                {
                    // extra var just to check 'value'
                    var _value = value;
                    // now always set it to false
                    _isChecked = false;
                    // Try to pass value of _isChecked to user interface
                    // because there is no check whether the value really
                    // has changed
                    // But this only works if the setter is not being called
                    // directly from the control the property is bound to
                    OnPropertyChanged();
                }
            }
    
            private ICommand _switchChecked;
    
            // ICommand for normal button, binding to Command
            // calls method to set Property for ToggleButton
            public ICommand SwitchIschecked
            {
                get
                {
                    if ( _switchChecked == null )
                        _switchChecked = new ChangeChecked( new Action( ChangeVar ));
                    return _switchChecked;
                }
                set
                {
                    _switchChecked = value;
                }
            }
    
            // This will set the property for the ToggleButton
            private void ChangeVar()
            {
                IsChecked = !IsChecked;
            }
            
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void OnPropertyChanged( [CallerMemberName] string propertyName = null )
            {
                var handler = PropertyChanged;
                handler?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
            }
    
    
        }
    
    
        /// <summary>
        /// Quick class to implement ICommand
        /// </summary>
        class ChangeChecked : ICommand
        {
            Action _execute;
            public ChangeChecked( Action execute )
            {
                _execute = execute;
            }
    
            public event EventHandler CanExecuteChanged;
    
            public bool CanExecute( object parameter )
            {
                return true;
            }
    
            public void Execute( object parameter )
            {
                _execute();
            }
        }
    }
