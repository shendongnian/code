    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]            // <= I needed to add this attribute
        private static void Main()
        {
           //...
        }
    }
    
    public partial class MainForm : Form () 
    {    
        // you can call this in the InitializeComponents() for instance
        void someMethodInYourFormIERunningOnTheUIThread()
        {
            ScanLib scanLib  = null;
            var th = new Thread(() =>
            {
                scanLib = new ScanLib();
            });
            th.SetApartmentState(ApartmentState.MTA); // <== this prevented binding the UI thread for some operations
            th.Start();
            th.Join();
            this.scanLibraryReference = scanLib;
        }
        //...
    }
