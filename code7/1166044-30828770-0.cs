     private static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            listener.Start();
            while (!bw.CancellationPending)
            {
                TcpClient client = listener.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(ThreadProc, client);
            }
            listener.Stop();
        }
