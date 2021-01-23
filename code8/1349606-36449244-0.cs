     System.Threading.Timer timer = null;
     int counts=0;
                timer = new Timer((obj) => 
                    {
                        dosomething();
                        if(++counts > 10)
                           timer.Dispose();  
                    },null,100,100); //check every 100ms
