    public partial class frm_Main : Form
    {
        public frm_Main()
        {
    
        }
        private void LaunchSetting()
        {
           var settings = new frm_Settings(this);
           settings.ShowDialog();
        }
        public void ChangeBackColor(Color color)
        {
            richTextBox.BackColor = color;
        }
    }
