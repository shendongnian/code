       Void APressed()
        {
             Speed = 5;
    ReduceSpeedAfter5Seconds();
        }
    
    
    public async Task ReduceSpeedAfter5Seconds()
    {
        await Task.Delay(5000);
        Speed = 0;
    }
