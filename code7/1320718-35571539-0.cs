       try
        {
           if (IsErrorValidation)
           {
                throw new Exeption("You input wrong data");
           }
        }
        catch (Exeption e)
        {
          MessageBox.Show("Error" + e.Massage)
        }
