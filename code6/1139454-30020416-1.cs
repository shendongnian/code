    public partial class Form1 : Form
    {
        private void OpenConfigForm()
        {
            OpenConfigForm opConfig = new formOpConfig();
            opConfig.UpdateData += (sender, e) => updatedata();
        }
        // Note that this method is private...no one else should need to call it
        private void updatedata()
        {
            //data update
        }
    }
