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
            public bool IsValidVoucher(string id)
            {
                // Call through object instance instead for class reference
                var temp1 = _appData.GetAppData("stringval");
            }
        }
