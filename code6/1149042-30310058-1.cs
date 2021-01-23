    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows;
    using System.Windows.Threading;
    public partial class App : Application
    {
        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // All unhandled exceptions come here. A stacktrace is saved as a text file with date and time.
            StackTrace st = new StackTrace(e.Exception);
            string fileName = DateTime.Now.ToString().Replace('/', '-').Replace(':', '-') + " errors.txt";
            fileName = @"C:\Users\Public\" + fileName;
            System.Windows.MessageBox.Show("Critical Error. Closing program.\nStacktrace can be found:" + fileName);
            using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                using (var strWrite = new StreamWriter(stream))
                {
                    strWrite.Write(st.ToString());
                }
            }
            if (MainWindow != null)
            {
                MainWindow.Close();
            }
            else
            {
                Environment.Exit(0);
            }
            e.Handled = true;
        }
    }
