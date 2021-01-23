    // This is your helper class that actually does the work
    public class ToolStarter 
    {
        public void startTool(string name)
        {
            // Put your switch statement here to decide what work to do
        }
    }
    
    public class ButtonWorker
    {
        private Button button;
        private ToolStarter toolStarter;
    
        public ButtonWorker(Button button, ToolStarter toolStarter)
        {
            this.button = button;
            this.toolStarter = toolStarter;
    
            this.button.Enabled = false;
            this.button.Text = "Starting";
    
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork));
        }
    
        private void DoWork(object state)
        {
            this.toolStarter.startTool(button.Name);
    
            // Pass control back to the UI thread so you can update your 
            // button text and enabled/status
            this.button.Invoke(new Action(() => 
            {
                this.button.Text = "Autoruns";
                this.button.Enabled = true;
            }));
        }
    }
    
    // This is just showing you how to use the ButtonWorker
    public class ButtonWorkerTest
    {
        public ButtonWorkerTest()
        {
            var btn1 = new Button { Name = "button1" };
            var btn2 = new Button { Name = "button2" }; 
            var toolstarter = new ToolStarter(); // This is your class
    
            var worker1 = new ButtonWorker(btn1, toolstarter);
            var worker2 = new ButtonWorker(btn2, toolstarter);
        }
    }
