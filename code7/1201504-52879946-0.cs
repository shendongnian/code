    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    namespace NumericBox
    {
        public partial class NumericBox : TextBox
        {
            public NumericBox
            {
                this.TextAlign = HorizontalAlignment.Right;
                this.Text = "0,00";
                this.KeyPress += NumericBox_KeyPress;
            }
            
            public double NumericResult
            {
                get{
                    double d = Convert.ToDouble(this.Text.Replace('.', ','));
                    return d;
                }
            }
            private void NumericBox_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                    e.Handled = true;
    
                if ((e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1))
                    e.Handled = true;
    
                if (e.KeyChar == 13)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
            }
        }
    }
