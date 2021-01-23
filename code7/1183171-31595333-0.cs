    public async void Run(IBackgroundTaskInstance taskInstance)
        {
            Debug.WriteLine("Task triggered");
            var deferral = taskInstance.GetDeferral();
            var bandInfo = (await BandClientManager.Instance.GetBandsAsync()).FirstOrDefault();
            IBandClient bandClient = null;
            if (bandInfo != null)
            {
                Debug.WriteLine("Band found");
                try
                {
                    bandClient = await BandClientManager.Instance.ConnectAsync(bandInfo);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex);
                }
                if (bandClient != null)
                {
                    try
                    {
                        Debug.WriteLine("Band connected: " + bandClient.GetFirmwareVersionAsync().Result);
                        var bandContactState = await bandClient.SensorManager.Contact.GetCurrentStateAsync();
                        Debug.WriteLine(bandContactState.State == BandContactState.NotWorn
                            ? "Band not worn"
                            : "Band worn");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Exception 1: "+ ex);
                    }
                }
            }
            if (bandClient != null)
            {
                deferral.Complete();
                bandClient.Dispose();
                bandClient = null;
            }
        }
