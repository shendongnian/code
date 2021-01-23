                switch (checkedListBox1.SelectedItem.ToString().Trim())
                {
                    case "First Quarter":
                        foreach (string s in checkedListBox1.CheckedItems)
                        {
                            sum += Convert.ToInt32(gvdisplay.Rows[i].Cells[10].Value);
                            txtTotalGST.Text = sum.ToString(); 
                        }
                        MessageBox.Show("Its feb");
                        break;
                    case "Second Quarter":
    //.......//
