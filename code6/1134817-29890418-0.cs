            OleDbCommand b = myCommand;
            int c = ExecuteScalarSwallowException(b, 24);
            int d = ExecuteScalarSwallowException<int>(b, 33);
        private static int ExecuteScalarSwallowException(OleDbCommand oleDbCommand, int defaultValue)
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
        private static T ExecuteScalarSwallowException<T>(OleDbCommand oleDbCommand, T defaultValue)
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
