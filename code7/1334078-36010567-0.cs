     private static string appGuid = "39E8A84A-A531-4399-9B55-B480CB1C9B1D";
            //test
            [STAThread]
            static void Main()
            {
                using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
                {
                    bool CheckAnotherInstance = true;
                    if (CheckAnotherInstance && !mutex.WaitOne(0, false))
                    {
                        MessageBox.Show("Only one executable can be run at the same time");
                        return;
                    }
    
                    RunProgram();
                }
            }
