    private void Thread1_Exe()
    {
        try
        {
            int sleepValT1;
            listBoxT1.Dispatcher.Invoke(() => sleepValT1 = Convert.ToInt32(listBoxT1.SelectedValue));
            int StartLoop = 0;
            int EndLoop = 10000;
            for (int i = StartLoop; i <= EndLoop; i++)
            {
                Dispatcher.BeginInvoke(
                new Action(() =>
                listboxE1.Items.Add("T1: Execution Count> " + i.ToString())));
                Thread.Sleep(sleepValT1);
            }
        }
        catch (Exception Ex)
        {
            MessageBox.Show(Ex.Message);
        }
    }
    private void thread1_Click(object sender, RoutedEventArgs e)
    {
        threadBtn1.IsEnabled = false;
        
        Thread t1 = new Thread(() => Thread1_Exe());
        t1.Start();
    }
