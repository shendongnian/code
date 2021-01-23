    public class MyHeaderService : IHeaderService {
        public string GetOsType() {
            var request = HttpContext.Current.Request;
            var testName = request.Headers.GetValues("OS Type")[0];
            return testName;
        }
    }
