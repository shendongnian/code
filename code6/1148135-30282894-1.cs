    for(int i = 0; i < 100; i++)
            {
                int j = i;
                Thread t2 = new Thread(() => ThreadWriting(j));
                t2.IsBackground = true;
                t2.Name = String.Format("Thread {0}", j);
                t2.Start();
            }
