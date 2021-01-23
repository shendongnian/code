                //path to your file
                string path = @"D:\your\path\to\excel\file.xlsx";
                // noitice that parameter HRD=YES if your file has header
                string connStr = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES""", path);
                    
                    
                using (OleDbConnection connection = new OleDbConnection(connStr))
                    {
                       connection.Open();
                       // ensure that sheet name is correct
                       OleDbCommand command = new OleDbCommand("select * from [sheet$]", connection);
                       using (OleDbDataReader dr = command.ExecuteReader())
                           {
                              // here you can access rows and insert them respectively
                              //first column , first row
                              var name = dr[0].toString();
                              //second column , first row
                              var lastname = dr[1].toString();
                              //here you can do anything with this variables (ex insert to db)
                           }
                    
                    }
