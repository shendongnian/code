            try
            {
               if (IsErrorValidation())
               {
                    throw new ErrorValidationException("You input wrong data");
               }
            }
            catch (ErrorValidationException e)
            {
              MessageBox.Show("Error" + e.Message);
              CloseProgram();
            }
            catch (Exeption e)
            {  
               ...
            } 
