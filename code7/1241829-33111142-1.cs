          try
            {
                // Database operations starts 
                //perform database opertions
                tranctaion.Commit();
            }
            catch (DataException ex)
            {
                
                //Roll back
                tranctaion.RollBack();
                //I'm keeping the original error but lying about the stack stace
                throw new InvalidOperationException(name, ex);
            }
