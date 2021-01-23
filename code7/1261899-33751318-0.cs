     else if (checkedListBox1.GetItemCheckState(iy) == CheckState.Unchecked)
            {
                foreach (Control con in this.Controls)
                {
                    if(con is TextBox)
                    {
                        if (t.Name == iy.ToString())
                        {
                          this.Controls.Remove(t);
                          t.Dispose();
                          break;
                        }
                    }
                }
                break;
            }
