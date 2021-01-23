     private async Task PollDb()
        {
            int lastCount = -1;
            while (true)
            {
                await Task.Delay(15000);    // 15 second interval
                var newRecord = await Task.Factory.StartNew <ICollection<object>>(p =>
                {
                    /* Get results here */
                    return new List<object>();
                });
                if(newRecord.Count() != lastCount)
                {
                    // Update app
                }
                lastCount = newRecord.Count();
            }
        }
