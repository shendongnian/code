    public class FormMain : Form {
        public static FormMain Instance = new FormMain();
        public void WriteToConsoldr(string consolCmd)
        {
            textBoxConsol.AppendText(consolCmd + "\n");
            textBoxConsol.AppendText("Tena_Consol>");
        }
    
        public static void WriteToConsole(string consolCmd)
        {
            Instance.Write_To_Consol_dr(consolCmd);
        }
    }    
    public class OtherClass 
    {
        public void SomeMethod()
        {
            FormMain.WriteToConsole("Some text");
            // Or access the instance method directly
            FormMain.Instance.WriteToConsoldr("Some text");
        }
    }
