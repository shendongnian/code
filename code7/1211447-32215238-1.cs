    void edit_mode(object sender, EventArgs e, string x,string y, int c, int z)
    {
        ...
        ...
        this.Hide();
        Form edits = new Form4();
        edits.ShowDialog();
        this.Show();
    }
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.Shown += Form4_Shown;
            // These lines doesn't make sense because you are creating a 
            // different instance of Form1. This instance (named backs) is 
            // not the same instance that creates the Form4 
            // Form backs= new Form1();
            // backs.Show();
            // Moved to the Form4_Shown event handler
            // this.Close();
    
        }
        public void Form4_Shown(object sender, EventArgs e)
        {
            // Move here the code that was previously in the constructor
            ....
            ....
            this.Close();
        }
