    public class Log
    {
        private Form1 _form;
        public Log(Form1 formToUpdate)
        {
            _form = formToUpdate;
        }
    
        public void AddLog(string s)
        {
            _form.richTextBox1.Text += Environment.NewLine + s;
        }
    }
