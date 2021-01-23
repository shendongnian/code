    string[] postSource = dt_1
                        .AsEnumerable()
                        .Select<System.Data.DataRow, String>(x => x.Field<String>("MoM_ID"))
                        .ToArray();
    
    var source = new AutoCompleteStringCollection();
    source.AddRange(postSource);
      TextBox_FormID.AutoCompleteCustomSource = source;
      TextBox_FormID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      TextBox_FormID.AutoCompleteSource = AutoCompleteSource.CustomSource;
