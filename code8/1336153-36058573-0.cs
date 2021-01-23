            string[] words = Languages.Split(',');
            foreach (string word in words)
            {
                foreach (GridViewRow row in gdvHealthProblem.Rows)
                {
                    if (row.Cells[1].Text == word)
                    {
                        CheckBox chkRow = row.Cells[0].FindControl("chkTableHealthProblem") as CheckBox;
                        chkRow.Checked = true;
                    }
                }
            }
