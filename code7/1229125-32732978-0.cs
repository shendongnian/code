    public async Task<HttpResponseMessage> SendPost(SuperComplex request)
    public class SuperComplex {
        public Application Application { get; set; }
        public AnotherObject Object { get; set; }
    }
    $http.post("/api/AController/SendPost", { application: application, Object: {} });
