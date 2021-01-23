     private async void OnGoButtonClick(object sender, EventArgs e)
     {
                var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                await Task.WhenAll(_listBox.Items
                    .OfType<string>() 
                    .Select(
                        taskArgument => 
                        Task.Run(async () => await DoLongTermApplicationAsync(taskArgument))
                            .ContinueWith(previousTask => _listBox.Items[_listBox.Items.IndexOf(taskArgument)] = previousTask.Result, uiScheduler) // refreshing the gui part while all other staff is in progress.
                            )
                    .ToArray());
       }
    
       private async Task<string> DoLongTermApplicationAsync(string taskInformation)
       {
            await Task.Delay(1000 + _random.Next(1000));
            return $"Processed {taskInformation}";
       }
