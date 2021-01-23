        public Task TaskA(object o)
        {
            //Do stuff
            //Fire and Forget: call Task B, 
            //create a new task, dont await 
            //but forget about it by moving to the next statement
            TaskB(); 
            //return;
        }
        public  Task TaskB()
        {
            //...
        }
        public async Task Client()
        {
            var obj = "data";
            //this will await only for TaskA
            await TaskA(obj);
        }
     
