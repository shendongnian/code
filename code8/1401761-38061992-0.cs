            public void callbackFunct(object state)
            {
                var myParams = (CustomParametersWithWaitHandle)state;
                string name = myParams.Parameter1;
                AutoResetEvent wh = myParams.WaitHandle;
                // code...
                listDog.Add(new Dog(name));
                // code...
                wh.Set(); // signal that this callback is done
            }
            public void Main()
            {
                // add dogs Bob each 10sec
                AutoResetEvent wh = new AutoResetEvent(false);
                var myCustomParams = new CustomParametersWithWaitHandle(wh, "bob", 314);
                Timer addbobs = new Timer(new TimerCallback(callbackFunct), myCustomParams, 0, 10000);
                wh.WaitOne(); // blocks here until `Set()` is called on the AutoResetEvent
                Console.WriteLine(listDog[0].name);
            }
        }
        public class CustomParametersWithWaitHandle
        {
            public AutoResetEvent WaitHandle { get; set; }
            public string Parameter1 { get; set; }
            public int Parameter2 { get; set; }
            public CustomParametersWithWaitHandle(AutoResetEvent h, string parameter1, int parameter2)
            {
                WaitHandle = h;
                Parameter1 = parameter1;
                Parameter2 = parameter2;
            }
