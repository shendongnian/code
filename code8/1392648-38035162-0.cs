    class Program
    {
        private static activeXControl _acx = new activeXControl();
        [STAThread]
        static void Main(string[] args)
        {
            // User input loop thread, use Ctrl + Z to exit loop
            Thread thread = new Thread((ThreadStart)
            delegate
            {
                string input;
                do
                {
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        continue;
                    }
                    switch (input)
                    {
                        case "Function1":
                            acx.Invoke(new Action(() => _acx.Function1()));
                            break;
                        case "Function2":
                            acx_.Invoke(new Action(() => acx_.Function2()));
                            break;
                        default:
                            Console.WriteLine("Method not found");
                            break;
                    }
                } while (input != null);
            });
            thread.IsBackground = true;
            thread.Start();
            // Create control and subscribe to events
            _acx.CreateControl();
            _acx.Event1 += new System.EventHandler(acx_Event1);
            _acx.Event2 += new System.EventHandler(acx_Event2);
            // Start message loop
            Application.Run();
        }
        private static void acx_Event1(object sender, EventArgs e)
        {
            // Write event output to console
        }
        private static void acx_Event2(object sender, EventArgs e)
        {
            // Write event output to console
        }
    }
