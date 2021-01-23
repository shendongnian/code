    var bag =new ConCurrentBag<Task?();
    using (StreamReader sr = new StreamReader(path))
    {
        while(sr.Peek >=0)
        {
            if(ConCurrentBag.Count < 10)
            {
                Task processing = sr.ReadLineAsync().ContinueWith( (read) => {
                    string s = await read;
                    //process line
                });
                bag.Add(processing);
                //processing remove from bag when complete
            }
            else Task.Yield();
        }
    }
