    for(int i = 0; i < dt.Rows.Count; i++)
           {
               ListName.Add(new SelectListItem
               {
                   Value = dt.Rows[i]["CountryId"].Tostring(),
                   Text = dt.Rows[i]["CountryName"].Tostring()
                   Selected=dt.Rows[i]["You respective field"].Tostring().Equals(name)?true:false
               });
           }
