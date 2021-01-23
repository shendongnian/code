    class Program
        {
            static void Main()
            {
                int count = 7;
    
                Class1 cl = new Class1();
                for (int i = 0; i < count; i++)
                {
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += new DoWorkEventHandler(
                    delegate(object o, DoWorkEventArgs argss)
                    {
                        BackgroundWorker b = o as BackgroundWorker;
    
                        cl.Print("id", "password");
                    });
    
                    bw.RunWorkerAsync();//Start the background here
    
                }
    
                Console.ReadLine();
            }
        }
    
        class Class1
        {
            public void Print(string id, string password)
            {
                Console.WriteLine("Id:{0},Password:{1}", id, password);
            }
        }
