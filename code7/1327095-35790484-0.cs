    public class Client
    {
        public void CallServerMethod_ApproachOne()
        {
            Server s = new Server();
            var sw = System.Diagnostics.Stopwatch.StartNew();
            s.LongLongTimeMethod_ApproachOne();
            sw.Stop();
            MessageBox.Show(sw.ElapsedMilliseconds.ToString());
        }
    
        public void CallServerMethod_ApproachTwo()
        {
    
            Server s = new Server();
            var elapsedMilliseconds = s.LongLongTimeMethod_ApproachTwo();
            MessageBox.Show(elapsedMilliseconds.ToString());
        }
    }
    public class Server
    {
        public void LongLongTimeMethod_ApproachOne()
        {
            //this is just a way to waste time, your real work is done here 
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(new Random().Next(1, 10)));
            return;
        }
    
        public long LongLongTimeMethod_ApproachTwo()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(new Random().Next(1, 10)));
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
