    public class PostEventArgs : EventArgs { public string Data { get; set; } }
    public event EventHandler<PostEventArgs> postDone;
    public void PostData(string data)
    {
        var client = new HttpClient();
        var task = client.PostAsync("uri", new StringContent(data));
        task.ContinueWith((t) =>
        {
            t.Result.Content.ReadAsStringAsync().ContinueWith((trep) =>
            {
                string response = trep.Result;
                if (postDone != null)
                    postDone(this, new PostEventArgs() { Data = response });
            });
        });
    }
