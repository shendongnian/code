    Stopwatch sw = new Stopwatch();
    public void 
    {
        If (checkbox1.checked)
        {
           random1.class1();    //action 1
           random2.class2();   //action 2
           sw.start();
        }
        If (checkbox2.checked)
        {
            Random2.class1();    //action 3
            var timeToSleep = (int)Math.Max(100 - sw.ElapsedMilliseconds, 0);
            Thread.Sleep(timeToSleep);
            sw.stop(); //You stop the watch here, you're measuring the time from task2 to task4, not the time which action 4 takes to execute
            Random2.class2();   //action 4
            
        }
        MessageBox.Show(sw.Elapsed.TotalMilliseconds.ToString());
    }
