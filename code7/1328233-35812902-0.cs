    public partial class Form2 : Form
    {
        // private List of Person(s)
        private List<Person> PersonsList = new List<Person>();
        // Public Read-only property that you can call from you Parent Form
        public List<Person> Frm2PersonsList
        {
            get
            {
                return this.PersonsList;
            }
        }
        public Form2()
        {
            InitializeComponent();
        }
        private void btnGonder_Click(object sender, EventArgs e)
        {
            SendItems();
            this.Close();
        }
        public void SendItems()
        {
            Person pr = new Person();
            pr.telebe = "Set in form 2"; // set you Person properties here
            PersonsList.Add(pr);
        }
    }
