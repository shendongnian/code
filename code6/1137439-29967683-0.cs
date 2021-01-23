     var dynamicQuery = dt.AsEnumerable(); //to add dynamic where clause, first convert datatable to enumerable.
                        foreach(string name in columnName) //maintaining column names in a seperate list, as list would be dynamic
                        {
                            dynamicQuery = dynamicQuery.Where(r => (Convert.ToDecimal(r[name]) <= list[columnName.IndexOf(name)]));
                        }
                        int count=dynamicQuery.Count();
