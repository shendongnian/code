    public partial class MainWindow : Window {
        public MainWindow() {
          InitializeComponent();
          CreateData();
    
          DeleteGroupCommand = new TestCommand(DeleteGroup);
    
          DataContext = this;
          
        }
    
        void CreateData() {
          Entries = new ObservableCollection<KeyValuePair<Group, Entry>>();
    
          Group group1 = new Group() { Name = "Group1" };
          Group group2 = new Group() { Name = "Group2" };
          Entry entry1 = new Entry() { Name = "Entry1", Val = "Val1" };
          Entry entry2 = new Entry() { Name = "Entry2", Val = "Val2" };
          Entry entry3 = new Entry() { Name = "Entry3", Val = "Val3" };
    
          Entries.Add(new KeyValuePair<Group, Entry>(group1, entry1));
          Entries.Add(new KeyValuePair<Group, Entry>(group1, entry3));
          Entries.Add(new KeyValuePair<Group, Entry>(group2, entry2));
          Entries.Add(new KeyValuePair<Group, Entry>(group2, entry3));
        }
    
        void DeleteGroup(object group) {
          // I want to run this when "Delete group" is selected from the context menu of the Group Expander.
          // I want the Group object associated with the Group Expander passed as the parameter
        }
    
        public ObservableCollection<KeyValuePair<Group, Entry>> Entries {
          get; set;
        }
        public ICommand DeleteGroupCommand { get; }
    
        public class Group {
          public string Name {
            get; set;
          }
        }
    
        public class Entry {
          public string Name {
            get; set;
          }
          public string Val {
            get; set;
          }
        }
    
        
      }
    
      public class TestCommand : ICommand {
        public delegate void ICommandOnExecute(object parameter);
    
        private ICommandOnExecute _execute;
    
        public TestCommand(ICommandOnExecute onExecuteMethod) {
          _execute = onExecuteMethod;
        }
    
        public event EventHandler CanExecuteChanged {
          add {
            CommandManager.RequerySuggested += value;
          }
          remove {
            CommandManager.RequerySuggested -= value;
          }
        }
    
        public bool CanExecute(object parameter) {
          return true;
        }
    
        public void Execute(object parameter) {
          _execute.Invoke(parameter);
        }
      }
