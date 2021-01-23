    SqlDataReader oReader = new SqlDataReader();
                while (oReader.Read())
                {
                    int oColumIndex = oReader.GetOrdinal("StudentID"); //Retrive the colunm index to get the data
    
                    Label oLabel = new Label() { Text = oReader.GetString(oColumIndex) };//Get the data with the retrived colum index and set as Text of my
                                                                                         //label instance, the you can add this label in any container
                }
