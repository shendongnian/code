    public interface IHttpHandler
    {
        HttpResponseMessage Get(string url);
        HttpResponseMessage Post(string url, HttpContent content);
        //workabyte: this was edited to cprrect a small typo that will now match the implementation. i am only adding this message as i needed to edit more than 6 chars
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
    }
