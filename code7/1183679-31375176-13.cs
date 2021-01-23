    public partial class frm_Main : Form
    {
        public frm_Main()
        {
    
        }
        private void LaunchSetting()
        {
           var settings = new frm_Settings(this);
           settings.OnColorChangedHandler += OnColorChanged;
           settings.ShowDialog();
        }
        private void OnColorChanged(Color color)
        {
           ChangeBackColor(color);
        }
        public void ChangeBackColor(Color color)
        {
            richTextBox.BackColor = color;
        }
    }
