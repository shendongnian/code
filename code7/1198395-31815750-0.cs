            Control ctl = this.Controls.Find("B1", true).FirstOrDefault();
            if (ctl != null)
            {
                // use "ctl" directly:
                listBox1.Items.Add(ctl.Text); 
                // or if you need it as a TextBox, then cast first:
                if (ctl is TextBox)
                {
                    TextBox tb = (TextBox)ctl;
                    // ... do something with "tb" ...
                    listBox1.Items.Add(tb.Text);
                }
            }
