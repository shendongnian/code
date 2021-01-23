    public class CustomTextBox : TextBox, ISomeInterfaceControl
    {
        public ISomeInterface SomeInterface { get; private set; }
        public CustomTextBox()
        {
            this.SomeInterface = new TextBoxSomeInterface(this);
        }
    }
