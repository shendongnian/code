         try
            {
                auth.Completed += domplete_facebook;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
