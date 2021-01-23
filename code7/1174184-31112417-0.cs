    private void button4_Click(object sender, EventArgs e) {
        string[] lines = File.ReadAllLines(@"c:\data\temp.txt");
        var options = new ParallelOptions { MaxDegreeOfParallelism = 4 };
        Parallel.ForEach(lines, options, line => {
            var request = WebRequest.Create(line);
            
            using (var res = request.GetResponse()) {
                var rd = new StreamReader(res.GetResponseStream(), Encoding.ASCII);
        
                BeginInvoke(new MethodInvoker(delegate {
                    textBox1.Text += ".";
                }));
            }
        });
    } 
