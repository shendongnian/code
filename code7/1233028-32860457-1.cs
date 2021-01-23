    public async Task<string> CallService()
    {
        client.DefaultRequestHeaders.Add("ContentType", "application/json");
        client.Timeout = TimeSpan.FromSeconds(5);
        var cts = new CancellationTokenSource();
        try
        {
            Toast.MakeText(this, "Sending Barcode " + newScan.ScanValue, ToastLength.Long).Show();
            await HttpPost(cts.Token);
            return "Success";
        }
        catch (Android.Accounts.OperationCanceledException)
        {
            return "timeout and cancelled";
        }
        catch (Exception)
        {
            return "error";
        }
    }
    private async Task HttpPost(CancellationToken ct)
    {
        var json = JsonConvert.SerializeObject(newScan);
        try
        {
            var response = await client.PostAsync("http://10.0.0.103:4321/Scan", new StringContent(json), ct);
            response.EnsureSuccessStatusCode();
            newScan.Success = "Success";
            codes.Add(DateTime.Now.ToShortTimeString() + "   " + newScan.ScanValue + " " + 
                "\n" + newScan.Success);
      
        }
        catch (Exception ex)
        {
            Log.Debug(GetType().FullName, "Exception: " + ex.Message);
            ErrorMessage = ex.Message;
        }
        finally
        {
            if (newScan.Success != "Success")
            {
               
                builder.Show();
                codes.Add(DateTime.Now.ToShortTimeString() + "   " + newScan.ScanValue + " \n" + ErrorMessage);
            }
        }
    }
