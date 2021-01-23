        client.SendAsync(request)
            .ContinueWith(responseTask =>
            {
                responseResult = responseTask.Result.Content.ReadAsStringAsync().Result;
                Dispatcher.Invoke(() => txtLog.Text = responseResult);
            });
