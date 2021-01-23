            List<string> pdfList = new List<string>();
            ...
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    pdfList.Add(reader["PdfCoding"].ToString());                                    
                }
            }
