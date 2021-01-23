    public partial class MainForm : Form
    {
        static backgroundProgram = new backgroundProgram(); //first declaration
     
        private void moduleScreen_Shown(Object sender, EventArgs e)
        {
            backgroundProgram.moduleNumber = 1;
            moduleScreen showForm = new moduleScreen();
            showForm.backgroundProgram = backgroundProgram; //give it this object
            //rest..
        }
    }
    public partial class moduleScreen : Form
    {
        public backgroundProgram; //no initialization. null from the beginning, set later.
        public void moduleScreen_Shown (Object sender, EventArgs e)
        {
           switch(backgroundProgram.moduleNumber) 
           {
              //...
           }
        }
    }
