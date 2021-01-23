        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (iy = 0; iy < checkedListBox1.Items.Count; iy++)
            {
                var item = checkedListBox1.Items[iy];
                string ctlName = item.ToString();
                Control txt = null;
                if (checkedListBox1.GetItemChecked(iy))
                {
                    txt = FindControl(ctlName);
                    if (txt != null)
                    {
                        continue;
                    }
                    txt = new TextBox();
                    txt.Name = ctlName;
                    txt.Text = ctlName;
                    txt.Location = new Point(150, 32 + (iy * 28));
                    txt.Visible = true;
                    this.Controls.Add(txt);                    
                }
                else if (checkedListBox1.GetItemCheckState(iy) == CheckState.Unchecked)
                {
                    txt = FindControl(ctlName);
                    if (txt==null)
                    {
                        continue;
                    }
                    this.Controls.Remove(txt);
                    txt.Dispose();                    
                }
            }
           
        }
        Control FindControl(String ctlName)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].Name==ctlName)
                {
                    return this.Controls[i];
                }
            }
            return null;
        }
