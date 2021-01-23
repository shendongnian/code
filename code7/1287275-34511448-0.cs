        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
                switch (keyData)
                {
                    case Keys.Tab:
                      if (txtBox1.Focused)
                      {
                          txtBox2.Focus();
                          return;
                      }
                      else if (txtBox2.Focused)
                      {
                          txtBox3.Focus();
                          return;
                      }
                      else if (txtBox3.Focused)
                      {
                          txtBox4.Focus();
                          return;
                      }
                      else if (txtBox4.Focused)
                      {
                          txtBox1.Focus();
                          return;
                      }
                        return base.ProcessCmdKey(ref msg, keyData);
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
