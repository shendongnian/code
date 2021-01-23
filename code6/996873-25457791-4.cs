    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Input;
    namespace WpfApplication1
    {
        public class MyViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            private string _source;
            public string Source { get { return _source; } set { _source = value; OnPropertyChanged("Source"); } }
            public ICommand ChangeImageCommand { get; private set; }
            private List<string> _pics = new List<string>()
            {
                "/Themes/Evernote.png",
                "/Themes/Skype.png", 
                "/Themes/Twitter.png"
            };
            private int i = 0;
            public MyViewModel()
            {
                this.Source = _pics[i++];
                this.ChangeImageCommand = new ActionCommand(ChangeImage);
            }
            private void ChangeImage()
            {
                this.Source = _pics[i++ % _pics.Count];
            }
        }
        public class ActionCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private Action _action;
            public ActionCommand(Action action) { _action = action; }
            public bool CanExecute(object parameter) { return true; }
            public void Execute(object parameter) { if (_action != null) _action(); }
        }
    }
