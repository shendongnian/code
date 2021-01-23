    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication
    {
        public class CustomTextBox : TextBox
        {
            public String WritePublicText
            {
                get { return Text; }
                set { Text = value; }
            }
        }
    }
