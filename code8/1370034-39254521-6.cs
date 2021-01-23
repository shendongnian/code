    [ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual)]
    public class YOUR_MAIN_CLASS
    {
        [return: MarshalAs(UnmanagedType.BStr)]
        public string FN_RETURN_TEXT(string iMsg)
        {
    
            return "You have sent me: " + iMsg + "...";
        }
    }
