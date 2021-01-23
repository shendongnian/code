    using System;
    using WinHelp = APClientHelpPane;
    
    class Program {
        static void Main(string[] args) {
            var obj = new WinHelp.HxHelpPaneServer();
            string docpath = @"C:\Windows\Help\Windows\ContentStore\en-US\windowsclient.mshc";
            obj.DisplayContents(docpath);
        }
    }
