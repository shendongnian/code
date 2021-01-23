    List<string> query = new List<string>();
    foreach (HtmlTableRow tr in tableStates.Controls)
    {
        foreach (HtmlTableCell tc in tr.Cells)
        {
            foreach (Control c in tc.Controls)
            {
                 if (c is CheckBox)
                 {
                      CheckBox chk = (CheckBox)c;
                      if (chk.Checked)
                      {
                           query.Add(chk.Text);
                      }
                  }
            }
        }
                    
    }
    string line = string.Join(" or ", query.ToArray());
    tbTest.Text = line;
