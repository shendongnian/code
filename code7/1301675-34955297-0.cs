    using System;
    using System.Text;
    using System.IO;
    using System.Windows.Forms;
    
    namespace ConsoleRedirection
    {
        public class TextBoxStreamWriter
        {
            TextBox _output = null;
    
            public TextBoxStreamWriter(ref TextBox output)
            {
                _output = output;
            }
    
            public void Write(char value)
            {
                _output.AppendText(value.ToString());
            }
            public void Write(string value)
            {
                _output.AppendText(value);
            }
            public Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
    
            public void clear()
            {
                _output.Clear();
            }
    
            public void textColor(System.Drawing.Color color)
            {
                _output.ForeColor = color;
            }
        }
    }
