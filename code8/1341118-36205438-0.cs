    public class ViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _text;
        public string Text {
            get { return _text; }
            private set {
                if (_text != value ) {
                    _text = value;
                    OnPropertyChanged("Text");
                }
            }
        }
        public ICommand Cmd { get; private set; }
        public ViewModel() {
            Text = "Press me";
            Cmd = new Command(() => {
                System.Diagnostics.Debug.WriteLine("Pressed!");
                Text = "Thanks!";
            });
        }
        private void OnPropertyChanged(string propertyName) {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    //.....
    
    public App ()
    {
        Button button = new Button();
        button.BindingContext = new ViewModel();
        button.SetBinding(Button.TextProperty, "Text");
        button.SetBinding(Button.CommandProperty, "Cmd");
    
        // The root page of your application
        MainPage = new ContentPage {
            Content = new StackLayout {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    button,
                }
            }
        };
    }
