    public class MenuD
    {
        public void SomeMethod()
        {
            try
            {
                // do something that could throw an exception
            }
            catch (Exception ex)
            {
                var isLogged = Log.Error(ex);
            }
        }
    }
