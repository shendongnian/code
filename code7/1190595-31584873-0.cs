    public class BaseForm : Form
        {
            public BaseForm()
            {
                Messenger.Default.Register<ChangeFontMessage>(this, message =>
                {
                    SetFont(message.FontSize);
                });
            }
    
            private void SetFont(float fontSize)
            {
                Font = new Font(Font.FontFamily, fontSize);
    
                //If you need to change font size of child controls
                foreach (var control in Controls.OfType<Control>())
                {
                    control.Font = new Font(control.Font.FontFamily, fontSize);
                }
            }
        }
    
        public class ChangeFontMessage
        {
            public float FontSize { get; set; }
        }
