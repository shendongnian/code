    namespace UI.Model {
        public class City : Client.Model.City, IDataErrorInfo
        {
            public String Error { get { return ""; } }
        }
    }
