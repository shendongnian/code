    async Task SendAfterDelay()
    {
        try
        {
            await Task.Delay(TimeSpan.FromMinutes(5));
            Sendafter5mins(param1,params2);
        }
        catch (Exception e)
        {
            // handle exception
        }
    }    
  
