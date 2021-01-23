        private static void Main()
        {
            if (PR__DevMode)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginScreen());
            }
            else
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new LoginScreen());
                }
                catch (Exception)
                {
                    if (PR__Username != null && PR__Username != "")
                    {
                        try
                        {
                            TryToLogout();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(
                                "A Critical Error has occurred AND the program Failed to log you out \nPlease Contact the Administrator to log you out \n You May not be connected to the Network \n\n" + e.Message +
                                "\n The Program Will Now Crash!", "Critical Error ", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    throw;
                }
            }
        }
