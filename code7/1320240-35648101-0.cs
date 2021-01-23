                QueryExpression qe = new QueryExpression
                {
                    EntityName = entity,
                    ColumnSet = col,
                    Criteria = new FilterExpression
                    {
                        Conditions = { 
                        new ConditionExpression("accountid",ConditionOperator.NotNull),
                        new ConditionExpression("statecode",ConditionOperator.Equal,0)
                    }
                    }
                };
                qe.PageInfo = new PagingInfo();
                qe.PageInfo.PagingCookie = null;
                qe.PageInfo.PageNumber = 1;
                qe.PageInfo.Count = 500;
    while (true)
                {
                    EntityCollection results= sp.RetrieveMultiple(qe);
                    if (results.Entities != null)
                    {
                        
                    }
                    // Check for more records, if it returns true.
                    if (results.MoreRecords)
                    {
                        Console.WriteLine("\n****************\nPage number {0}\n****************", pagequery.PageInfo.PageNumber);
                        Console.WriteLine("#\tAccount Name\t\tEmail Address");
                        // Increment the page number to retrieve the next page.
                        pagequery.PageInfo.PageNumber++;
                        // Set the paging cookie to the paging cookie returned from current results.
                        pagequery.PageInfo.PagingCookie = results.PagingCookie;
                    }
                    else
                    {
                        // If no more records are in the result nodes, exit the loop.
                        break;
                    }
                }
