    var bag =new ConCurrentBag<Task>();
    using (StreamReader sr = new StreamReader(path))
    {
        while(sr.Peek() >=0)
        {
            if(bag.Count < 10)
            {
                Task processing = sr.ReadLineAsync().ContinueWith( (read) => {
                    string s = read.Result;//EDIT Removed await to reflect Scots comment
                    //process line
                });
                bag.Add(processing);
            }
            else
            {
                Task.WaitAny(bag.ToArray())
                //remove competed tasks from bag
            }
        }
    }
