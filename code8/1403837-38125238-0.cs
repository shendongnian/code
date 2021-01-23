    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        class CustomTab:TabPage
        {
            public RichTextBox textbox;
            public CustomTab()
            {
                textbox = new RichTextBox();
                this.Controls.Add(textbox);
                textbox.Dock = DockStyle.Fill;
            }
        }
    }
