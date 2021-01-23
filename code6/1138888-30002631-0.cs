    public class Form1 : System.Windows.Forms.Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData )
        {
            if( keyData == Keys.Tab)
            {
                ExecuteYourTabProcessinLogicHere();
                // Returning TRUE here halts the normal behavior of the 
                // TAB key, you could change this based on the result 
                // of your logic
                return true; 
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
