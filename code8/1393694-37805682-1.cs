    var dtAsEnum= ds.Tables[0].AsEnumerable();
    string ProjectName= (from r in dtAsEnum
                  where r.Field<string>("Employee") == 'LoggedInUser'
                  select r.Field<string>("Project")).First<string>();
     Label.Text = ProjectName;
