    public partial class Form1 : Form
    {
        //I want to use these lists in the UserControl class
        List<Person> persons = new List<Person>(); 
        List<Conditions> conditions = new List<Conditions>();
        List<Missions> missions = new List<Missions>();
        Tools tools = new Tools();
        public Form1()
        {
            InitializeComponent();
        }
        // here gets some code that will create an instance of your CellUI class
        // and pass the list through the constructor whenever you like to
    }
    public partial class CellUI : UserControl
    {
        // List to catch the List from the main form
        List<Person> persList;
        //Hand it over in the Constructor
        public CellUI(List<Person> pList)
        {
            InitializeComponent();
            persList = pList;
        }
        //Here I want to get the List<Person> object, and fill a ComboBox 
        private void CellUI_Load(object sender, EventArgs e)
        {
            // populate the combobox with persons
        }
        // like - cbCellPersonsList.Add(*all the items in persons from the main form*); 
        private void cbCellPersonsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //when index changes, change Label lblPersonName in the cusom control
        }
    }
