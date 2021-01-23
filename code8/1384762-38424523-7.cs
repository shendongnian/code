    public class TestPathProvider : IPathProvider {
        public string MapPath(string path) {
            return Path.Combine(@"C:\project\",path);
        }
    }
