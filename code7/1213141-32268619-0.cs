    [ComVisible(true)]
    public interface IExample {
        object ImportoDocumento { get; set; }
    }
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class Example : IExample {
        private decimal documento;
        public object ImportoDocumento {
            get { return documento; }
            set { documento = Convert.ToDecimal(value, null); }
        }
    }
