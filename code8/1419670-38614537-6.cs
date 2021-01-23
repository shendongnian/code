     public class MainViewModel : INotifyPropertyChanged {
        private INotifyPropertyChanged _selectedViewModel;
    
        public MainViewModel() {
          var cmd = new RelayCommand(x => {
            MessageBox.Show("HelloWorld");
          }, x => true);
          this.RVM = new ReadViewModel(cmd);
          this.WVM = new WriteViewModel(cmd);
          this.SelectedViewModel = WVM;
        }
    
        private ICommand _switchViewModelCommand;
    
        public ICommand SwitchViewModelCommand => this._switchViewModelCommand ?? (this._switchViewModelCommand = new RelayCommand(x => {
          if (this.SelectedViewModel == RVM) {
    
            this.SelectedViewModel = WVM;
            return;
          }
          this.SelectedViewModel = RVM;
        }));
    
        public INotifyPropertyChanged SelectedViewModel {
          get {
            return this._selectedViewModel;
          }
          set {
            if (Equals(value, this._selectedViewModel))
              return;
            this._selectedViewModel = value;
            this.OnPropertyChanged();
          }
        }
    
        public ReadViewModel RVM {
          get; set;
        }
    
        public WriteViewModel WVM {
          get; set;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    
      public class ReadViewModel : INotifyPropertyChanged {
        public ReadViewModel(ICommand sayHelloCommand) {
          this.HelloCommand = sayHelloCommand;
        }
    
        public ICommand HelloCommand {
          get;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    
      public class WriteViewModel : INotifyPropertyChanged {
    
        public WriteViewModel(ICommand sayHelloCommand) {
          this.HelloCommand = sayHelloCommand;
        }
    
        public ICommand HelloCommand {
          get;
        }
    
        public ICommand HelloMoonCommand => new RelayCommand(x => { MessageBox.Show("Hello Moon"); });
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    
        }
      }
