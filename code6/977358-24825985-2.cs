    private void TryAndRepeat(Action routine, int maxAttempts)
        {
            int attempts = 1 ;
            bool success = false;
            while (!success && attempts <= maxAttempts)
            {
                try
                {
                    routine.Invoke();
                    success = true;
                }
                catch
                {
                    if (attempts >= maxAttempts)
                    {
                        throw;
                    }
                }
                attempts++;
            } 
        }
