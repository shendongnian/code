        private int _maxAttempts = 10;
        private void TrySendMail(int attemptNumber)
            Task.Factory.StartNew(() => SendMail("mail@example.com", "Test title", "TEST body"), CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default)
            .ContinueWith(p =>
            {
                attemptNumber++;
                if (p.IsFaulted)
                {
                    if (p.Exception != null)
                    {
                        if (_attempts < _maxAttempts)
                        {
                            // Try again
                            TrySendMail(attemptNumber);
                        }
                        else
                        {
                            MessageBox.Show(p.Exception.ToString());
                        }
                    }
                    return;
                }
                success = true;
                MessageBox.Show("ok");
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
