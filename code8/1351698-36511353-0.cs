    class Worker {
        public bool shoudstop {get; set;}
        public bool isrunning {get; set;}
        
        //....
        public void DoWork() {
            isrunning = true;
            shouldstop = false;
            while (!shouldstop) {
                //do your business logic here
                Console.WriteLine("hello world ...");
            }
            isrunning = false;
        }
        // ...
    }
