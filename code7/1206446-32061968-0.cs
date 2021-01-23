    public partial class Form1 : Form
    {
        // Set the variables here
        string aaxe = null;
        string atre = null;
    
        public Form1()
        {
            InitializeComponent();
        }
       
        public void Treasure_Click(object sender, EventArgs e)
    {
        if (atre == null)
        {
            richTextBox1.AppendText("You Haven't Found the Treasure Yet!\r\n");
            // When you call a variable, you don't need to add the 'string' type. this will re-declare the variable.
            aaxe = "y"
        }
        if (atre == "y")
        {
            richTextBox1.AppendText("You Found The Treasure!!!\r\n");
            richTextBox1.AppendText("The End Of The Adventure!");
        }
    }
