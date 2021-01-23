    // DocumentDB query 
     // POINT TO PONDER: create the formatted query, so that after creating the   dynamic query we'll replace it with dynamically created "SQL Parameter/s"
                var queryText = @"SELECT
    			                    us.id,
                                    us.email,			
    	                            us.status,
                                    us.role
                                FROM user us
                                WHERE us.status = @userStatus AND us.email IN ({0})";
    
    			// contain's list of emails  
    			IList<string> emailIds = new List<string>();
    			emailIds.Add("a@gmail.com");
    			emailIds.Add("b@gmail.com");
    
                #region Prepare the query
    
    			// simple parameter: e.g. check the user status
    			var userStatus = "active";
                var sqlParameterCollection = new SqlParameterCollection { new SqlParameter("@userStatus", userStatus) };    			
    			
    			// IN clause: with list of parameters:
    			// first: use a list (or array) of string, to keep  the names of parameter			
    			// second: loop through the list of input parameters ()
                var namedParameters = new List<string>();
                var loopIndex = 0;
    
                foreach (var email in emailIds)
                {
                    var paramName = "@namedParam_" + loopIndex;
                    namedParameters.Add(paramName);
    
                    var newSqlParamter = new SqlParameter(paramName, email);
                    sqlParameterCollection.Add(newSqlParamter);
    
                    loopIndex++;
                }
    
                // now format the query, pass the list of parameter into that
                if (namedParameters.Count > 0)
                    queryText = string.Format(queryText, string.Join(" , ", namedParameters));
    				
    				// after this step your query is something like this  
    				// SELECT
    			    //                 us.id,
                    //                 us.email,			
    	            //                 us.status,
                    //                 us.role
                    //             FROM user us
                    //             WHERE us.status = @userStatus AND us.email IN (@namedParam_0, @namedParam_1, @namedParam_2)
    
                #endregion //Prepare the query
    
    			// now inject the parameter collection object & query
                var users = Client.CreateDocumentQuery<Users>(CollectionUri, new SqlQuerySpec
                {
                    QueryText = queryText,
                    Parameters = sqlParameterCollection
                }).ToList();
			
