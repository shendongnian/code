    public class BackgroundProgram
    {
        public static int moduleNumber; 
    }
    
    public partial class moduleScreen : Form
    {
        //no own static fields of that object
        public void moduleScreen_Shown (Object sender, EventArgs e)
        {
           switch(BackgroundProgram.moduleNumber) //Refer to the static field of that class
           {
              //...
           }
        }
    }
