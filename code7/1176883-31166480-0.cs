    private static string PrepareExecuteCommand (string sqlParameterizedCommand, object [] parameterArray) 
        {
            int arrayIndex = 0;
            foreach (var obj in parameterArray)
            {
                if (obj == null || Convert.IsDBNull(obj)) 
                {
                    sqlParameterizedCommand = sqlParameterizedCommand.Replace("{" + arrayIndex + "}", "NULL"); 
                }
                else
                    sqlParameterizedCommand = sqlParameterizedCommand.Replace("{" + arrayIndex + "}", obj.ToString());
                ++arrayIndex;
            }
            return sqlParameterizedCommand;
        }
