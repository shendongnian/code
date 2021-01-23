    namespace Running_Total
    {
        public partial class frmEnter : Form
        {
             // declare your Array here
             string [] array = new string[1000];
             int count = 0;
    
             public frmEnter()
             {
                InitializeComponent();
             }
    
             private void btnDisplay_Click(object sender, EventArgs e)
             {
                 // save input
                 array[count] = inputTextBox.Text;
                 count++;
                 // display whole input
                 string output = "";
                 for(int i = 0;i < count; i++)
                 {
                     output += array[i];                     
                 }
                 // write it the texbox
                 outputTextBox.Text = output;
             }
    }
