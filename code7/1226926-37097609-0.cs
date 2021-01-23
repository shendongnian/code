    namespace AmiCOMLib
    {
        [ComVisible(true)]
        public interface IMyInterop
        {
            [DispId(1)]
            void SendQuotes(string quoteString);
        }//end interface  
        [ComVisible(true)]
        public class AmiCOM
        {
            public void SendQuotes(string quoteString)
            { 
                //process string here and save as CSV
            }
        }
      }
