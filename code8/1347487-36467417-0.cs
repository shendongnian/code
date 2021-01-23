    private void getnameid2()
            {
                PersonDataSet newPersonDataSet = new PersonDataSet(); //PersonDataSet is the manually created dataset
                PersonDataSetTableAdapters.L_PEOPLETableAdapter newPersonDataSetTableAdapter = new PersonDataSetTableAdapters.L_PEOPLETableAdapter(); 
                DataTable mytable = new DataTable();
                mytable = newPersonDataSetTableAdapter.GetData(decimal.Parse(this.civilidTextbox.Text.ToString()));
    //foreach (DataRow row in newPersonDataSetTableAdapter.GetData(decimal.Parse(this.civilidTextbox.Text.ToString()))
                foreach (DataRow row in mytable.Rows)
                {
                   
                    nameTextBox.Text = row["FIRST_NAME"].ToString();
                    personidTextBox.Text = row["PERSON_ID"].ToString();
                }
    
                // if (mytable.Rows.Count > 0) { MessageBox.Show(mytable.Rows.Count.ToString()); }
                                
            }
