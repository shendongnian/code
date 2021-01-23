        try
            {
                // Database operations starts 
                //perform database opertions
                tranctaion.Commit();
            }
            catch // anything goes wrong
            {
                
                //Roll back
                tranctaion.RollBack();
                //Rethowing the *Same* exception
                throw;
            }
