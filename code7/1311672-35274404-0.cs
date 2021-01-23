    public class TextBoxListener : TraceListener
    {
        RichTextBox _box;
        string _data;
        public TextBoxListener(string data)
        {
            _data = data;
        }
    
        private bool Init()
        {
            if (_box != null && _box.IsDisposed )
            {
                // back to null if the control is disposed
                _box = null;
            }
            // find the logger text box
            if (_box == null)
            {
                // open forms
                foreach (Form f in Application.OpenForms)
                {
                    // controls on those forms
                    foreach (Control c in f.Controls)
                    {
                        // does the name match 
                        if (c.Name == _data && c is RichTextBox)
                        {
                            // found one!
                            _box = (RichTextBox) c;
                            break;
                        }
                    }
                }
            }
            return _box != null && !_box.IsDisposed;
        }
    
        public override void WriteLine(string message)
        {
            if (Init())
            {
                _box.Text = _box.Text + message + "\r\n";
            }
        }
    
        public override void Write(string message)
        {
            if (Init())
            {
                _box.Text = _box.Text + message;
            }
        }
    }
