    public class SettingsForm : Form
    {
        public TimeSpan TimerTime {get; set;}
        public int Setting1 {get; set;}
        public string Setting2 {get; set;}
        public void OnButtonOk_Clicked(object sender, ...)
        {
            if (!this.AllValuesOk())
            {   // error in one of the values
                // show message box
            }
            else
            {
                this.Close();
            }
        }
    }
