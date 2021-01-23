    private static string GetUserInfoByName(string name)
        {
            StringBuilder tasks = new StringBuilder();
            // THIS WOULD BE A CALL TO THE DB TO RETURN THE RAW VALUES FOR A USER
            var userInfo = _userInfo.Find(e => e.Name == name);
            // TEST FOR TASKS HAVING THE VALUE OF TRUE
            if(userInfo.Task1)
            {
                tasks.Append("Task1,");
            }
            if(userInfo.Task2)
            {
                tasks.Append("Task2,");
            }
            if(userInfo.Task3)
            {
                tasks.Append("Task3");
            }
            // CONVERT STRING BUILDER TO A STRING
            var result = tasks.ToString();
            // REMOVE THE LAST COMMA IF WE HAVE ONE
            if(result.EndsWith(","))
            {
                result = result.Remove(result.Length - 1);
            }
            return result;
        }
