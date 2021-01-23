    private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Str = "";
                if (checkedListBox1.CheckedItems.Count > 0)
                {
                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        if (Str == "")
                        {
                            Str = checkedListBox1.CheckedItems[i].ToString();
                            label1.Text = Str;
                        }
                        else
                        {
                            Str += ", " + checkedListBox1.CheckedItems[i].ToString();
                            label1.Text = Str;
                        }
                    }
                    // Make your connection to the DataBase and insertion code starting within that area.
                    MessageBox.Show("Your selection is for :" + Str);
                }
                else
                {
                    MessageBox.Show("Please select one name at least to work it out!");
                }
                while (checkedListBox1.CheckedItems.Count > 0)
                {
                    checkedListBox1.SetItemChecked(checkedListBox1.CheckedIndices[0],false);
                }
                            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.ToString());
            }
        }
