    public class FormMain : Form {
        public void WriteToConsoldr(string consolCmd)
        {
            textBoxConsol.AppendText(consolCmd + "\n");
            textBoxConsol.AppendText("Tena_Consol>");
        }
    
        public static void WriteToConsole(SDK.FormMain clasi, string consolCmd)
        {
            clasi.Write_To_Consol_dr(consolCmd);
        }
    }    
