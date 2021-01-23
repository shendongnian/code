    public static object locker =  new object();
        public static void InitBrowser(int browser)
        {
            var thread = new Thread(() =>
            {
                // Create Browser Here
                Monitor.Wait(locker);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    button1.click()
    {       
       Monitor.Enter(locker);
       for(int i = 0;i <= converttoint32(textbox1.text);i++)
        InitBrowser(textbox2.text);
    }
    button2.click()
    {
        Monitor.PulseAll(locker);
    }
