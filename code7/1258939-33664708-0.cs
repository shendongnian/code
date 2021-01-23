                DataTable dt = new DataTable("movieAndActorType");
                dt.Columns.Add("actorId", typeof(Int32));               
                for (int i = 0; i < actors.Length; i++)
                {
                    var newRow = dt.NewRow();
                    newRow["actorId"] = actors[i];
                    dt.Rows.Add(newRow);
                }
            
