    public class BaseForm : Form
    {
        public BaseForm()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            this.Load += BaseForm_Load;
            this.FormClosed += BaseForm_FormClosed;
        }
        private IEnumerable<Control> GetAllControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControls(ctrl)).Concat(controls);
        }
        void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log(string.Format("{0} Closed", this.Name));
        }
        void BaseForm_Load(object sender, EventArgs e)
        {
            Log(string.Format("{0} Opened", this.Name));
            GetAllControls(this).OfType<Button>().ToList()
                .ForEach(x => x.Click += ButtonClick);
        }
        void ButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null) Log(string.Format("{0} Clicked", button.Name));
        }
        public void Log(string text)
        {
            var file = System.IO.Path.Combine(Application.StartupPath, "log.txt");
            text = string.Format("{0} - {1}", DateTime.Now, text);
            System.IO.File.AppendAllLines(file, new string[] { text });
        }
    }
