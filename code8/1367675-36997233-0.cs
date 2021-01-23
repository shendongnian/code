            foreach (DataRow row in dt.Rows)
            {
                //get the values in position column that is not null (This does not work)
                var position = row.Field<string>("Position");
                if (string.IsNullOrEmpty(position))
                {
                    //Null or empty
                }
                else
                {
                    //Not null
                }
            }
