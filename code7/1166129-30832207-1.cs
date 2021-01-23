    public partial class YourForm : Form
    {
        private YourContext context=new YourContext();
        public BindingList<Person> BindingList { get; set; }
        private void YourForm_Load(object sender, EventArgs e)
        {
            context.People.Load();
            this.listBox1.DataSource= BindingList= context.People.Local.ToBindingList();
            this.listBox1.DisplayMember = "Name";
        }
        
        //Button for save new changes
        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }
        //Disposing the context before close the form
        private void YourForm_FormClosing(object sender, FormClosingEventArgs e) 
        { 
            context.Dispose(); 
        } 
    }
