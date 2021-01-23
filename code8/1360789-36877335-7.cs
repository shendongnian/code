    public class MainLibrary
        {
            public bool OpenWindow() //found no ref to bool isRunning
            {
    
                using (var mw = new MainWindow())
                {
                    mw.ShowDialog();
                    mw.Close();
                }
                    
                return true;
            }
    
            public bool CloseWindow()
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                return true;
            }
        }
