    private void Thread1_Exe()
    {
        try
        {
            int sleepValT1;
            listBoxT2.Dispatcher.Invoke(() => sleepValT1 = Convert.ToInt32(listBoxT2.SelectedValue));
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
    private void thread2_Click(object sender, RoutedEventArgs e)
    {
        threadBtn2.IsEnabled = false;
        
        Thread t2 = new Thread(() => Thread2_Exe());
        t2.Start();
    }
