    namespace DTDemo
    {
       public partial class Form1 : Form
       {
          private DateTime datetime;
          System.Timers.Timer timer = new System.Timers.Timer(1000);
          public Form1()
          {
              InitializeComponent();
              timer.Elapsed += timer_Elapsed;
          }
          void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
          {
            MethodInvoker method = new MethodInvoker(delegate{
            datetime = DateTime.Now;
            String time = datetime.Hour + ":" + datetime.Minute + ":" + datetime.Second;
            label1.Text = time; 
            });
            if (label1.InvokeRequired)
                label1.Invoke(method);
            else
                method();
		}
          private void button1_Click(object sender, EventArgs e) // start button
          {
              timer.Start();
          }
          private void button2_Click(object sender, EventArgs e) //stop button
          {
              timer.Stop();
              label1.Text = " ";
          }
        }
      }
