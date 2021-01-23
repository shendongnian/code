    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class AddInUtilities : 
        StandardOleMarshalObject,
        IExcelUtilities
    {
        public bool DoSomething()
        {
            return true;
        }
    }
