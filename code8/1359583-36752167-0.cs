    public partial class MainForm : Form
    {
        static backgroundProgram = new backgroundProgram(); //first declaration
 
        private void moduleScreen_Shown(Object sender, EventArgs e)
        {
            backgroundProgram.moduleNumber = 1;
            //rest..
        }
    }
