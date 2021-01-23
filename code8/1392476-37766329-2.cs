    public interface IHttpClient {
        System.Threading.Tasks.Task<T> GetAsync<T>(string uri) where T : class;
        System.Threading.Tasks.Task<T> GetAsync<T>(Uri uri) where T : class;
        //...other members as needed : DeleteAsync, PostAsync, PutAsync...etc
    }
