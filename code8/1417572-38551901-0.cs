    public partial class Form1 : Form
    {
         public static Form1 Instance { get; private set; }
         private void Form1_Load(object sender, EventArgs e)
         {
              Instance = this;
         }
    }
