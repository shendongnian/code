            for (var i = 0; i < 15; i++)
            {
                cashDrawer = GetCashDrawer(posExplorer);
                cashDrawer.Open();
                cashDrawer.Claim(1000);
                cashDrawer.DeviceEnabled = true;
                if (!cashDrawer.DrawerOpened)
                {
                    Console.WriteLine("waited");
                    return;
                }                    
                cashDrawer.Release();
                cashDrawer.Close();
                System.Threading.Thread.Sleep(1500);
            }
            Console.WriteLine("timed out");
