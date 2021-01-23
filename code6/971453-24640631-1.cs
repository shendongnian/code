        private async void bla... [..]
    {
        Exception exc= null;
        try
        {
        //All your stuff
        }
    
    
        catch(Exception ex)
        {
        
         exc = ex;
        
        }
        if(exc!=null)
        await msg.ShowAsync();
    }
