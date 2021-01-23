    [Microsoft.SqlServer.Server.SqlFunction(TableDefinition="IDs nvarchar(max)"]
    public static IEnumerable GetSubStrings(string text)
    {
           List<string> IDs=new List<string>();
           foreach (Match match in Regex.Matches(text, @"(?<!\w)@\w+"))
           {
               try
               {
                    IDs.Add(match.Value.Replace("@", ""));
               }
               catch (NullReferenceException) { continue; }
           }
           return IDs;
    }
