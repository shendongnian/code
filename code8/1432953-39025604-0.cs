    catch (Exception ex)            
    {                
        if (ex is FormatException)
        {
            if (string.IsNullOrEmpty(this.textboxName.Text){ 
                MessageBox.Show("U must enter something");
            } else {
                MessageBox.Show("It must be an integer");
            }
            return; 
         } 
         else if (ex is SqlException) {
            MessageBox.Show(ex.Message);
            return;
         }
       throw;
    }
