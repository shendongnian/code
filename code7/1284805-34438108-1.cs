        else if (e.Reply == null)
        {
            Console.WriteLine("Pinging {0} failed. (Null Reply object?)", ip);
        }
        countdown--;
        if(countdown==0)
        {
            sw.Stop();
            TimeSpan span = new TimeSpan(sw.ElapsedTicks);
            listBox1.Items.Add("Took {0} milliseconds. {1} hosts active. "+ 
                                sw.ElapsedMilliseconds+" "+ upCount);
        }
    }
