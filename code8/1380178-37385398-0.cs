    foreach (Control control in groupBox1.Controls)
            {
                string controlType = control.GetType().ToString();
                var lst = new List<string>() { "System.Windows.Forms.TextBox" ,"System.Windows.Forms.ComboBox"};
                //if (controlType == "System.Windows.Forms.TextBox")
                if (lst.Contains(controlType, StringComparer.OrdinalIgnoreCase))
                {
                   // TextBox txtBox = (TextBox)control;
                   // ComboBox combo = (ComboBox)control;
                    if (string.IsNullOrEmpty(control.Text) && string.IsNullOrEmpty(control.Text))
                    {
                        MessageBox.Show(control.Name + " Can not be empty");
                    }
                }
