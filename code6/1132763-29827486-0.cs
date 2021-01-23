    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        // a loop that never exits !!!!
        // no break, no cancel, nothing!!!
        while (true) 
        {
            // here is the Background thread
            //... and absolutely NOTHING happens here...
            // the code that follows gets invoked on the UI thread
            // (which defeats the purpose of the BackgroundWorker...)
            // then immediately returns (because it's asynchronous)
            // to be invoked again
            // and again, and again...
            // (Is your app unresponsive perhaps? doesn't it hang?)
            this.BeginInvoke((Action)(() =>
            {
                red_light1 = comport.message(4, 8, 32); 
                if (red_light1 == "1") 
                {
                    ellipse1.FillEllipse(red_on, 250, 133, 24, 24);
                }
                else
                { 
                    ellipse1.FillEllipse(red_off, 250, 133, 24, 24);
                    }));
                    // Your UI hangs here !!!
                    // (Because you're putting your UI thread to sleep!)
                    // At least call Thread.Sleep() in the background thread.
                    // Or call synchronous Invoke() instead of asynchronous BeginInvoke()
                    // so your background thread waits untill the operation on UI thread
                    // is completed before trying to perform it again
                    Thread.Sleep(300);
                }
            }
        }
    }
