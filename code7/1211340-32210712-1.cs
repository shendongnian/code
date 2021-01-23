      List<string> l=new List<String>();
                foreach (DataColumn dc in table.Columns)
                {
				  var Sum= table.AsEnumerable().Sum(x => x.Field<double>(dc));
                  l.Add(Sum.ToString());
                }
