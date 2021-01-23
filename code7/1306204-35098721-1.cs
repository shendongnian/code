        void OpenSerialConnection(int portnumber, System.Windows.Forms.NotifyIcon TrayIcon)
        {
			//Get console window
            handle = ConsoleHelper.GetConsoleWindow();
            var handleINT32 = handle.ToInt32();
            if (handleINT32 == 0)
            {
				//Create the console window
                ConsoleHelper.AllocConsole();
            }
            handle = ConsoleHelper.GetConsoleWindow();
			
			//Show console window
            ConsoleHelper.ShowWindow(handle, ConsoleHelper.SW_SHOW);
			
			//Remove close button from console window (can only be closed from code now)
            ConsoleHelper.DeleteMenu(ConsoleHelper.GetSystemMenu(ConsoleHelper.GetConsoleWindow(), false), ConsoleHelper.SC_CLOSE, ConsoleHelper.MF_BYCOMMAND);
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.PortName = "COM" + portnumber.ToString();
                    serialPort1.BaudRate = Form1.BaudRate;
                    serialPort1.Open();
                }
                catch (Exception error)
                {
                    TrayIcon.ShowBalloonTip(3000, "Error in " + error.Source.ToString(), "The program encountered an error while trying to open the serial connection. This may be due to closing the program prematurely. Try unplugging your board and restarting the program!", System.Windows.Forms.ToolTipIcon.Error);
					//Hide console window
                    ConsoleHelper.ShowWindow(handle, ConsoleHelper.SW_HIDE);
                }
            }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("====CONSOLE OPENED ON (COM PORT " + portnumber.ToString() + ")=======");
            Console.WriteLine("===========BAUD RATE: " + Form1.BaudRate.ToString() + "=============");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
