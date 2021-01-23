    namespace WpfApplication3
    {
    	public class PersonViewModel
    	{
    		public PersonViewModel(string name, int age)
    		{
    			this.name = name;
    			this.age = age;
    		}
    
    		public string Name
    		{
    			get { return name; }
    		}
    		private string name;
    
    		public int Age
    		{
    			get { return age; }
    		}
    		private int age;
    	}
    
    	public class MainViewModel
    	{
    		public MainViewModel()
    		{
    			persons = new ObservableCollection<PersonViewModel>()
    			{
    				new PersonViewModel("Lez", 146),
    				new PersonViewModel("Binja", 158),
    				new PersonViewModel("Rufus the Destroyer", 9000)
    			};
    		}
    
    		public ObservableCollection<PersonViewModel> Persons
    		{
    			get { return persons; }
    		}
    
    		private ObservableCollection<PersonViewModel> persons;
    	}
    	/// <summary>
    	/// Interaction logic for MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			this.DataContext = new MainViewModel();
    		}
    	}
    }
