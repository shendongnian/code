    public class CatchExceptions
    {
        public void SomeMethod ()
        {
            try
            {
                //some stuff that throws exceptions
            }
            catch (WebException e) if (e is LoginInfoException)
            {}
            catch (WebException e) if (e is ConnectionLostException)
            {}
        }
    }
