    for (int i = 0; i < (number_of_connections); i++)
    {
      Task[i] = new Thread(ThreadStart => Run_Client(UDP_Client_num[i, 0], UDP_Client_num[i, 1]));
      Task[i].Start();
      Thread.Sleep(100);   // <<-- This Solved the Problem
    }
