        static void slowly(string sen)
        {
            var thread = new System.Threading.Thread(() => {
                for (int j=0; j<sen.Length-1; j++)
                {
                    System.Console.Write(sen[j]);
                    System.Threading.Thread.Sleep(100);
                }
                System.Console.Write(sen[sen.Length-1]);
                System.Threading.Thread.Sleep(100);
            });
            thread.Start();
        }
