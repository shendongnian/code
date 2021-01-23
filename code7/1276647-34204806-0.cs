    Thread myThread = new Thread(() =>
            {
                ServiceController svc = new ServiceController("service name", "remote desktop name");
                svc.Start();
                svc.WaitForStatus(ServiceControllerStatus.Running, timer1);
                if (svc.Status == ServiceContrllerStatus.Running)
                {
                    Dispatcher.Invoke(() =>
                    { //This is required to acccess the Main UI Thread If you don't do this you will get and error
                        textBox8.Text = "Success";
                    });
                }
                else
                {
                    Dispatcher.Invoke(() =>
                    {
                        textBox8.Text = "Fail";
                    });
                }
            });
            myThread.Start();
