             try
            {
               if (IsErrorValidation)
               {
                    throw new ErrorValidationException("You input wrong data");
               }
            }
            catch (ErrorValidationException e)
            {
              MessageBox.Show("Error" + e.Massage)
            }
            catch (Exeption e)
            {  
               ...
            } 
