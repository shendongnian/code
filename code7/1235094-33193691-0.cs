            //create list in run time
            if (q.QuestionType == "MultiSelect")
            {
                 lstmulti = new ListBox();
                lstmulti.ID = "lst_" + q.ID;
                lstmulti.Width = Unit.Percentage(41);
                lstmulti.Height = Unit.Percentage(100);
                lstmulti.SelectionMode = ListSelectionMode.Multiple;
                
                //to retrive the option values
                if (!string.IsNullOrEmpty(q.Options))
                {
                    string[] values = q.Options.Split(',');
                    foreach (string v in values)
                        lstmulti.Items.Add(v.Trim());
                }
                tc.Controls.Add(lstmulti);
            }
                tc.Width = Unit.Percentage(80);
                tr.Cells.Add(tc);
                tbl.Rows.Add(tr);
            }
            pnlSurvey.Controls.Add(tbl);
        }
     
        
