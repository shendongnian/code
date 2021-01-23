            -- code remove for brevity
            ActivityIndicator.IsVisible = true;
            await Task.Delay(500); 
            try
            {
                await Navigation.PushAsync(new TransactionCalculationPage(), true);
            }
            finally
            {
                ActivityIndicator.IsVisible = false;
            }   
