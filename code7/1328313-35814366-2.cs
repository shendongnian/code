    Task.Factory.StartNew(()=>
    {
        Thread.Sleep(3000); // wait 3 secs
        form1.Invoke(new Action(()=> 
                   {
                        // your logic goes here.
                   }));
    });
