                        var task = ProcessMessage(message, queue, token).ContinueWith(x =>
                    {
                        while (true)
                        {
                            Task outTask;
                            if (runningTasks.TryRemove(x.Id, out outTask))
                                break;
                            Task.Delay(25);
                        }
                    });
