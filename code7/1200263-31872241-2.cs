        public interface IAppData
        {
            object GetAppData(string id);
        }
        
        public class AppDataWrapper : IAppData
        {
            public object GetAppData(string id)
            {
                return AppData.GetAppData(id);
            }
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
                var temp1 = _appData.GetAppData("stringval");
            }
        }
