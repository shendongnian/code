            OleDbCommand b = myCommand;
            int c = ExecuteScalarSuppressException(b, 24);
            int d = ExecuteScalarSuppressException<int>(b, 33);
        private static int ExecuteScalarSuppressException(OleDbCommand oleDbCommand, int defaultValue)
        {
            int returnValue = defaultValue;
            try
            {
                defaultValue = (int)oleDbCommand.ExecuteScalar();
            }
            catch (Exception)
            {
            }
            return defaultValue;
        }
        private static T ExecuteScalarSuppressException<T>(OleDbCommand oleDbCommand, T defaultValue)
        {
            T returnValue = defaultValue;
            try
            {
                defaultValue = (T)oleDbCommand.ExecuteScalar();
            }
            catch (Exception)
            {
            }
            return defaultValue;
        }
