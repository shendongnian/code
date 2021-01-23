        private CancellationTokenSource tokenSource;
        private string RequestID;
        ApiResponse response;
        private void form1_Load(object sender, EventArgs e)
        {
            freeUI();
        }
        private void do_stuff()
        {
            RequestID = api.SendRequest(info);
            DateTime fiveMinutesFromNow = GetFiveMinutesFromNow();
            response = null;
            while (response != null && now < fiveMinutesFromNow)
            {
                ApiResponse check = api.GetResponse(RequestID);
                if (check.status == "Complete")
                {
                    response = check;
                    tokenSource.Cancel();
                    break;  // <-- maybe you could remove this since the task was cancelled?
                }
                else
                {
                    //Wait for 3 seconds
                }
            }
            if (response.status == "Complete")
            {
                //Continue on
            }
        }
        private async Task freeUI()
        {
            await start_process();
            // do other things
        }
        private Task start_process()
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
            return Task.Factory.StartNew(() =>
            {
                do_stuff();
            }, token);
        }
