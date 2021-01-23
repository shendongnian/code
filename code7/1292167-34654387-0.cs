    private static void checkBoxeEnable()
            {
                var processInfo = new ProcessStartInfo("cmd.exe", "/c" + "\""+System.AppDomain.CurrentDomain.BaseDirectory+"Turn_On_Check_Boxes_to_Select_Items.bat\"");
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                processInfo.RedirectStandardError = true;
                processInfo.RedirectStandardOutput = true;
                var process = Process.Start(processInfo);
                process.Start();
                process.WaitForExit();
              
            }
