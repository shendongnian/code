    public class BaseForm : Form
    {
        [DefaultValue("Red")]
        public Color AccentColor { get; set; }
        public BaseForm()
        {
            this.AccentColor = Color.Red;
        }
    }
