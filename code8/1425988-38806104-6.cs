    public class FakePathProvider : IPathProvider {
        public string MapPath(string path) {
            return Path.Combine(@"C:\testproject\",path.Replace("~/",""));
        }
    }
