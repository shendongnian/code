    public static class Extensions
    {
        public static void DoSomething(this SqlConnection connection, int input)
        {
            //Do something
        }
    }
    //And then when you want to use it:
    SqlConnection connection = new SqlConnection();
    connection.DoSomething(3);
