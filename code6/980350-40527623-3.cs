    public static class SqlDataUtils
    {
        public static void SetParameters(this SqlCommand command, params SqlParameter[] parameters)
        {
            command.Parameters.AddRange(parameters);
        }
    }
