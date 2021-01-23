        public partial class _Default : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void BtnAdd_Click(object sender, EventArgs e)
            {
                List<Person> list = new List<Person>() { new Person("John"), new Person("Louis"), new Person("Walter") };
                Session["DataSource"] = list;
                UpdateListView();
            }
    
            protected void BtnUpdate_Click(object sender, EventArgs e)
            {            
                List<Person> list = (List<Person>)Session["DataSource"];
                list.Add(new Person("NewPerson"));
                Session["DataSource"] = list;
                UpdateListView();
            }
    
            private void UpdateListView()
            {
                ListView1.DataSource = (List<Person>)Session["DataSource"];
                ListView1.DataBind();
            }
        }
    
        public class Person
        {
            string _name;
    
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
    
            public Person(string nome)
            {
                _name = nome;
            }
        }
