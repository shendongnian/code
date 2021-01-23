        client.SendAsync(request)
            .ContinueWith(responseTask =>
            {
                responseResult = responseTask.Result.Content.ReadAsStringAsync().Result;
                txtLog.Text = responseResult;
            });
