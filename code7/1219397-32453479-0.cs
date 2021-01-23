    public class Form1 : Form
    {
        public Form1()
        {
            var button = new Button();
            button.Click += button1_Click;
            
            Controls.Add(button);
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            var obj = new ObjectWithTimer();
            
            Thread.Sleep(2000);
            obj.Deinit();
        }
    }
    
    public class ObjectWithTimer
    {
        public System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        bool disposed = false;
    
        public ObjectWithTimer()
        {
          timer.Interval = 100;
          timer.Tick += new EventHandler(timer_Tick);
          timer.Enabled = true;
        }
    
        public void Deinit()
        {
          timer.Enabled = false;
          timer.Tick -= new EventHandler(timer_Tick);
          timer.Dispose();
          timer = null;
          disposed = true;
        }
    
        private void timer_Tick(object sender, EventArgs e)
        {
          "Ticked".Dump();
        }
    }
