    public static void UpdateValue(DataRow dr, string property, object value)
        {
            Monitor.Enter(computerTable);
            try
            {
                dr[property] = value;
            }
            catch 
            {
                //Do something with errors
            }
            finally
            {
                Monitor.Exit(computerTable);
            }
        }
