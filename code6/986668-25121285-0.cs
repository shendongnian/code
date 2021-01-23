     using (var contents = con.CreateCommand())
            {
                contents.CommandText = "SELECT [_id], [name], [shortName],[defaultCompetitionRule_id] from [Competition]";
                var r = contents.ExecuteReader();
                while (r.Read())
                {
                    tl.Add(FromReader(r));
                }
                con.Close();
                ListAdapter = new ArrayAdapter<String>(this,  Android.Resource.Layout.SimpleListItem1, tl.Select(x => x.name).ToArray());
            }
