     public partial class Form1 : Form
        {
            private string[] servers = new[] { "server1", "server2", "server3" };
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private async void button1_Click(object sender, EventArgs e)
            {
                this.button1.Enabled = false;
                string guid = this.textBox1.Text;
    
                var _cts = new CancellationTokenSource();
                var token = _cts.Token;
                var tasks = new List<Task<Data>>();
    
                foreach (var server in this.servers)
                {
                    tasks.Add(this.GetData(guid, server, token));
                }
    
                var completedTask = await Task.WhenAny(tasks.ToArray());
                _cts.Cancel();
                var data = completedTask.Result;
                this.button1.Enabled = true;
            }
    
            private  async Task<Data> GetData(string guid, string database, CancellationToken cancellationToken)
            {
                try
                {
                    Random r = new Random();
                    //Simulate long running task
                    await Task.Delay(TimeSpan.FromSeconds(r.Next(1, 2)), cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    Debug.WriteLine("Operation was cancelled");
                    return null;
                }
                catch (Exception)
                {
                   
                }
    
                return new Data();
            }
        
        private class Data
        {
        }
    }
