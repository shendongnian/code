    // Bind BindingList to Listbox
    public class Form1 {
        BindingList<Person> personer = new BindingList<Person>();
        public Form1() {
            InitializeComponent();
            listBox1.DataSource = personer;
        }
    
    // Remove on button click
    private void button1_Click(object sender, EventArgs e)
    {
        if (listBox1.SelectedIndex > -1)
        {
            //This automatically updates your listBox
            personer.RemoveAt(listBox1.SelectedIndex);
        }
    }
    // Update on Button click
    private void button2_Click(object sender, EventArgs e)
    {
        if (listBox1.SelectedIndex > -1)
        {
            Person p = personer[listBox1.SelectedIndex];
            //Update person here
        }
        
    }
        
