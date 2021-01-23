     public class ResponseResultExtractor
        {
            public T Extract<T>(HttpResponseMessage response)
            {
                return response.Content.ReadAsAsync<T>().Result;
            }
        }
    var actual = ResponseResultExtractor.Extract<List<ListItems>>(message);
