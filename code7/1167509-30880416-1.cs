        public class Model
        {
            public Model() 
            {
                ChildList = new HashSet<Child>();
            }
            public ICollection<Child> ChildList { get; set; }
        }
        
        public class Child
        {
            public string Name { get; set; }
        }
        
        
        //View Model, now implements INotifyPropertyChanged    
        public class VM: INotifyPropertyChanged{
            private Model _model; 
            
            public VM()
            {
                var model = new Model();
                model.ChildList.Add(new Child { Name = "Child 1" });
                model.ChildList.Add(new Child { Name = "Child 2" });
                model.ChildList.Add(new Child { Name = "Child 3" });
                model.ChildList.Add(new Child { Name = "Child 4" });
            
                _model = model;
                Command = new DelegateCommand(CommandExecuted);
            }
            
            public ObservableCollection<Child> ChildCollection
            {
                get
                {
                    return new ObservableCollection<Child>(_model.ChildList);
                }
            }
    
            public DelegateCommand Command { get; set; }
            
            private void CommandExecuted()
            {
                _model.ChildList.Remove(SelectedChild);
                OnPropertyChanged("ChildCollection");
            }
            
            public Child SelectedChild { get; set; }   
            
            public event PropertyChangedEventHandler PropertyChanged;
            
            protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
           {
               var eventHandler = this.PropertyChanged;
               if (eventHandler != null)
               {
                   eventHandler(this, new PropertyChangedEventArgs(propertyName));
               }
           }
        }
            
            
        public class DelegateCommand : ICommand
        {
            private readonly Action _execute;    
            public DelegateCommand(Action execute)
            {
                _execute = execute;
            }
            
            public void Execute(object parameter)
            {
                _execute();
            }
            
            public bool CanExecute(object parameter)
            {
                return true;
            }
            
            public event EventHandler CanExecuteChanged;    
            }
           
        //View    
    <ListBox ItemsSource="{Binding Path = ChildCollection}" SelectedItem="{Binding SelectedChild}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <Label Content="{Binding Name}"/>
             </DataTemplate>
         </ListBox.ItemTemplate>
    </ListBox>
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new VM();
            }
        }
