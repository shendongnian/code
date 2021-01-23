        public interface IAppData
        {
            object GetAppData(string id);
        }
        public class AppData : IAppData
        {
            public object GetAppData(string id) {}
        }
        public class Foo
        {
            private readonly IAppData _appData;
            
            public Foo(IAppData appData)
            {
                _appData = appData;
            }
            public bool IsValidVoucer(string id)
            {
                // Call through object instance instead for mocking
                var temp1 = _appData.GetAppData("stringval");
            }
        }
