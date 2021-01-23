    public class MyClass
    {
        private List<TextBox> textboxes;
        public MyClass()
        {
            this.InitializeComponent();
            textboxes = new List<TextBox>(){ textbox1, textbox2, textbox3 };
        }
        
        private void UpdateTextBoxes(string aString)
        {
            for(var i = 0; i < textboxes.Count; i++)
            {
                textboxes[i].Text = aString;
            }
        }
    }
