    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using WpfApplication1.ViewModels;
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
            private ImageSource _source;
            public ImageSource Source { get { return _source; } set { _source = value; OnPropertyChanged("Source"); } }
            public ICommand ChangeImageCommand { get; private set; }
            private List<BitmapImage> _pics = new List<BitmapImage>()
            {
                new BitmapImage(new Uri("/Themes/Evernote.png", UriKind.Relative)),
                new BitmapImage(new Uri("/Themes/Skype.png", UriKind.Relative)),
                new BitmapImage(new Uri("/Themes/Twitter.png", UriKind.Relative))
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
