    public static class AsyncErrorHandler
    {
        public static void HandleException(Exception ex)
        {
            if (ex is ExceptionToThrowToUser)
            {
               MessageBox.Show(ex.Message);               
            }
            else
                Debug.WriteLine(ex.Message);
        }
    }
