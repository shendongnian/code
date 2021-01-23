     CompleteSource(dtAutocomplete, txtCity, "City");//(datatable , your textboxname , database feild name you want to bind like printername)
     
      public void CompleteSource(DataTable dtsource, TextBox txtname, string fieldname)
                {
                    AutoCompleteStringCollection autoitem = new AutoCompleteStringCollection();
    
                foreach (DataRow dr in dtsource.Rows)
                {
                    autoitem.Add(dr[fieldname].ToString());
                }
    
                txtname.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtname.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtname.AutoCompleteCustomSource = autoitem;
            }
