        private async void button1_Click(object sender, EventArgs e)
        {
            var lines=await Process1(@"dir g:\ /s");
            var result= String.Join("|", lines);
            this.textBox1.Text = result;
        }
        private async Task<HashSet<String>>   Process1(string parameters)
        {
            var list_result = new HashSet<string>();
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", "/c " + parameters);
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            Process process = Process.Start(processStartInfo);
            
            while (!process.StandardOutput.EndOfStream)
            {
                string line = await process.StandardOutput.ReadLineAsync();
                list_result.Add(line);
            }
            return list_result;
        }
