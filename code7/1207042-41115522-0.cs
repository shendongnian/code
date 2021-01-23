          try
            {
                // your code in here
            }
            catch (Exception ert)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ert));
            }
