    for(int i = 0; i < 100; i++)
            {
    
                Thread t2 = new Thread(() => ThreadWriting(i));
                t2.IsBackground = true;
                t2.Name = String.Format("Thread {0}", i);
                t2.Start();
            }
