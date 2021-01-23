            public void GetCars(string manufacturer, string model, string fuel, DateTime? year, string searchString)
            {
                string query = @"
                               SELECT *,
                               ISNULL([Manufacturer],'') + ' ' + ISNULL([Model],'') + ' ' ISNULL([Fuel],'') + ' ' ISNULL('Year', '') AS [SearchString]
                               FROM [MyDatabase]
                               WHERE [Manufacturer]=@Manufacturer ";
    
                if (!String.IsNullOrEmpty(model))
                    query += @"AND [Model]=@Model ";
    
                if (!String.IsNullOrEmpty(fuel))
                    query += "AND [Fuel]=@Fuel ";
    
                if (year.HasValue)
                    query += "AND [Year]=@Year ";
    
                if (!String.IsNullOrEmpty(searchString))
                    query += @"AND [SearchString] Like '%@SearchString%' ";
    
                using (SqlCommand sqlCommand = new SqlCommand(query))
                {
                    sqlCommand.Parameters.AddWithValue("@Manufacturer", manufacturer);
    
                    if (!String.IsNullOrEmpty(model))
                        sqlCommand.Parameters.AddWithValue("@Model", model);
    
                    if (!String.IsNullOrEmpty(fuel))
                        sqlCommand.Parameters.AddWithValue("@Fuel", fuel);
    
                    if (year.HasValue)
                        sqlCommand.Parameters.AddWithValue("@Year", year.Value);
    
                    if (!String.IsNullOrEmpty(searchString))
                        sqlCommand.Parameters.AddWithValue("@SearchString", searchString);
    
                    //Execute to data table etc
                }
            }
