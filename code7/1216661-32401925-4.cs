     int i;
        public MainWindow()
        {
             try { InitializeComponent(); }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
             i = 0;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int messages;
            i++;
            Stopwatch stoop = new Stopwatch();
            stoop.Start();
            messages = i;
            try
            {
                PipeLink.Sender.SendMessage(messages);
                stoop.Stop();
                Console.WriteLine(stoop.ElapsedMilliseconds + " ms");
            }
            catch (Exception u)
            {
                Console.WriteLine(u);
            }
        }
