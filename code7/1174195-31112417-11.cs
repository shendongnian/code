    private void button4_Click(object sender, EventArgs e)
    {
        var lines = File.ReadAllLines(@"c:\data\temp.txt");
        var options = new ParallelOptions { MaxDegreeOfParallelism = 4 };
        Parallel.ForEach(lines, options, line => 
        {
            var request = WebRequest.Create(line);
            
            using (var response = request.GetResponse()) 
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII);
                // Do your stuff
        
                BeginInvoke(new MethodInvoker(delegate 
                {
                    textBox1.Text += ".";
                }));
            }
        });
    } 
