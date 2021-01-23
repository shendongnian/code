    using System.Linq;
    using Microsoft.Office.Interop.Outlook;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                var app = new Application();
                var ns = app.GetNamespace("MAPI");
                ns.Logon();
                var inbox = ns.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
                var size = inbox.Items.OfType<dynamic>().Sum(s=>s.Size);            
            }
        }
    }
    
