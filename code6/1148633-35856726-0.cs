       //sample result entity 
       public class SearchResult
        {
            public int NumberOfPagesAvailable { get; set; }
            public int CurrentPageNumber { get; set; }
            public IEnumerable<ResultItem> ResultItems { get; set; }
    
        }
    	
    	
            /// <summary>
            /// Method to Create an output parameter
            /// </summary>
            /// <param name="paramName">The Parameter name</param>
            /// <param name="paramType">Type of the parameter</param>
            /// <param name="value">The value to set</param>
            /// <returns></returns>
            public static OracleParameter CreateOutputParameter(string paramName, OracleDbType paramType, object value)
            {
                var outParam = new OracleParameter(paramName, paramType, ParameterDirection.Output)
                {
                    Value = value ?? DBNull.Value
                };
    
                return outParam;
            }
    
    
    		//1 	create command
    		
    		//2 	created the params as below		
                OracleParameter pages = OracleHelper.CreateOutputParameter("p_pages", OracleDbType.Int64, null);
                OracleParameter pageNumber = OracleHelper.CreateOutputParameter("p_pageNumber", OracleDbType.Int64, null);
                OracleParameter resultSet = OracleHelper.CreateOutputParameter("p_resultSet");
    		//3 	execute using oralce command
    		
    		//4  	read the param values as below after executing the command
               if (pages.Value != null)
                {
                    result.NumberOfPagesAvailable = Convert.ToInt32(pages.Value.ToString());
                }
    
                if (pageNumber.Value != null)
                {
                    result.CurrentPageNumber = Convert.ToInt32(pageNumber.Value.ToString());
                }
    
    			          if (resultSet.Value != null && result.NumberOfPagesAvailable>0 && result.CurrentPageNumber>0)
                {
                    OracleRefCursor refCursor;
                        using (refCursor = (OracleRefCursor)resultSet.Value)
                        {
                            using (OracleDataReader rdr = refCursor.GetDataReader())
                            {
                               //iterate through the loop and read the values from the reader
    //set ResultItems 
                            }
                        }
                }
