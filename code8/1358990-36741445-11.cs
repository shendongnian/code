        int countimages = 0;
        Task tasks;
        bool StartUpdateTask = false;
        private  void UpdateTask()
        {
            if (StartUpdateTask)
            {
                tasks = Task.Run(() =>
                {
                   // Action to update paint. 
                     ...
                    if(countimages%10 == 0){
                      // Action to save paint
                      ...
                    } 
                    System.Threading.Interlocked.Increment(ref countimages);
                    UpdateTask();
                });
            }
        } 
   
     private void button_RunTest_Click(object sender, EventArgs e)
     {
            if (!StartUpdateTask &&( tasks == null || tasks.IsCompleted)) { 
               StartUpdateTask = true;
               UpdateTask();                
            }else
               StartUpdateTask = false;
 
            button_RunTest.BackColor = (StartUpdateTask) ? Color.Green : this.BackColor;              
        } 
 
