    if (reader.Read())
            {
                var readMore = true;
                while (readMore)
                {
                    var val = reader.GetValue(0).ToString();
                    readMore = reader.Read();
                    if (!readMore)
                    {
                        //Last record. Use val .
                        txtitemid.Text = val;
                    }
                    else
                    {
                        //Not last record. Process val differently.
                    }
                }
            }
