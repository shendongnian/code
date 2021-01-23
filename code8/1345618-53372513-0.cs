    Thread th = new Thread(() =>
                    {
                        System.Threading.Thread.Sleep(10000);
                        SendKeys.SendWait("{Tab}");
                        SendKeys.SendWait("{Tab}");
                        SendKeys.SendWait("{Tab}");
                        SendKeys.SendWait("{Enter}");
                        System.Threading.Thread.Sleep(5000);
                        SendKeys.SendWait("{Tab}");
                        SendKeys.SendWait("{Tab}");
                        SendKeys.SendWait("{Tab}");
                        SendKeys.SendWait("{Enter}");
                    });
                    th.SetApartmentState(ApartmentState.MTA);
                    th.Start();
