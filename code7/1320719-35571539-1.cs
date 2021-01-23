       try
        {
           if (IsErrorValidation)
           {
                throw new Exeption("You input wrong data");
           }
        }
        catch (Exception e)
        {
          MessageBox.Show("Error" + e.Massage)
        }
