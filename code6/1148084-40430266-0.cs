        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Waiting....";
            await MyLongJobAsync(3);
            label1.Text = "done";
        }
        private  Task<int> MyLongJobAsync(int seconds)
        {
            
            return Task.Run(
                ()=> {
                    return MyLongJob(seconds);
            });
        }
        private int MyLongJob(int seconds)
        {
            
           for (int i=0; i< seconds; i++)
            {
                label1.Invoke(new Action(() => label1.Text = (i+1) + " in  long running job"));
                Thread.Sleep(1000);
            }
           return seconds;
 
        }
 
