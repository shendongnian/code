     public partial class CustomForm : Form {
         public string lblText
            {
                get
                {
                    return lbl.Text;
                }
                set
                {
                    if (lbl.InvokeRequired)
                        lbl.Invoke((MethodInvoker) (() => lbl.Text = value));
                    else
                        lbl.Text = value;
                }
            }
    
     }
