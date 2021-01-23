    private void LoadAutoCompleteList()
            {
                DataTable d = MyMethodFetchesResults();
                AutoCompleteStringCollection s = new AutoCompleteStringCollection();
    
                foreach (DataRow row in d.Rows)
                {
                    s.Add(row[1].ToString());
                }
    
                txtSearchKey.AutoCompleteCustomSource = s;
            }
