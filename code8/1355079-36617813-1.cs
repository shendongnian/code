    void Main()
    {
      Application.Run(new LogForm());
    }
    
    public static class Log
    {
      public static async Task GenerateMessagesAsync(Action<string> logEvent, 
                                                CancellationToken cancel)
      {
        for (int i = 0; i < 1000; i++)
        {
          cancel.ThrowIfCancellationRequested();
          
          logEvent(i.ToString());
          
          await Task.Delay(1000, cancel);
        }
      }
    }
    
    public partial class LogForm : Form
    {
      private readonly List<string> messages;
      private readonly Button btnStart;
      private readonly Button btnStop;
      private readonly TextBox tbxLog;
      private readonly System.Windows.Forms.Timer timer;
    
      public LogForm()
      {
        messages = new List<string>();
      
        btnStart = new Button { Text = "Start" };
        btnStart.Click += btnStart_Click;
        Controls.Add(btnStart);
        
        btnStop = 
          new Button { Text = "Stop", Location = new Point(80, 0), Enabled = false };
        Controls.Add(btnStop);
        
        tbxLog = new TextBox { Height = 200, Multiline = true, Dock = DockStyle.Bottom };
        Controls.Add(tbxLog);
        
        timer = new System.Windows.Forms.Timer { Interval = 500 };
        timer.Tick += TimerProcessor;
        timer.Start();
      }
      
      private void TimerProcessor(object sender, EventArgs e)
      {
        foreach (var message in messages)
        {
          tbxLog.AppendText(message + Environment.NewLine);
        }
        
        messages.Clear();
      }
    
      private async void btnStart_Click(object sender, EventArgs e)
      {
        btnStart.Enabled = false;
        var cts = new CancellationTokenSource();
        EventHandler stopAction = (_, __) => cts.Cancel();
        btnStop.Click += stopAction;
        btnStop.Enabled = true;
        
        try
        {
          await Log.GenerateMessagesAsync(message => messages.Add(message), cts.Token);
        }
        catch (TaskCanceledException)
        {
          messages.Add("Cancelled.");
        }
        finally
        {
          btnStart.Enabled = true;
          btnStop.Click -= stopAction;
          btnStop.Enabled = false;
        }
      }
      
      protected override void Dispose(bool disposing)
      {
        if (disposing)
        {
          timer.Dispose();
          btnStart.Dispose();
          btnStop.Dispose();
          tbxLog.Dispose();
        }
        
        base.Dispose(disposing);
      }
    }
