    ExecuteThread(() =>
                        {
                            try
                            {
                                MessageListener();
                            }
                            finally
                            {
                                _messageListenerCompleted.Set();
                            }
                        });
