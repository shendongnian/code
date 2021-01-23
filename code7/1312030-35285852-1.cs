    publci class FormDesignManager 
    {
        public static Form CreateForm(string xmlPath)
        {
            var form = new Form();
            //design the controls for the form
            //you can get System.Windows.Forms.TextBox or any other controls from the xml
            var control = typeof(Control).Assembly.GetType("System.Windows.Forms.TextBox", true);
            var textBox = Activator.CreateInstance(textBoxType);
            return form;
        }
    }
