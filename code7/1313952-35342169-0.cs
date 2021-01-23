    if (list != null)
    {
       while (continue_)
       {
           i++;
           Thread.Sleep(5000);
           Thread thrd1 = new System.Threading.Thread(() => Test());
           thrd1.Start();
       }
    }
