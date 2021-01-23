    void edit_mode(object sender, EventArgs e, string x,string y, int c, int z)
    {
        ...
        ...
        this.Hide();
        Form edits = new Form4();
        edits.ShowDialog();
        this.Show();
    }
}
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            ...
            ...
            ...
            // These lines doesn't make sense because you are creating a 
            // different instance of Form1. This instance (named backs) has
            // nothing to do with the instance that creates the Form4 (named edits
            // in the previous code
            // Form backs= new Form1();
            // backs.Show();
            this.Close();
    
        }
