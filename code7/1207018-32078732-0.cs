       private void wifiButton_Click(object sender, EventArgs e)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "netsh.exe";
            System.Threading.Thread.Sleep(50);
            cmd.StartInfo.Arguments = "wlan show profiles";
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardError = true;
            cmd.Start();
            //* Read the output (or the error)
            string output = cmd.StandardOutput.ReadToEnd();
            textBox3.Text = output;
            cmd.WaitForExit();
            System.Threading.Thread.Sleep(500);
            // output would be set by earlier code
            var Output = textBox3.Text;
            var regex = new Regex(@"All User Profile[\s]+: (.*)");
            var resultList = new List<string>();
            foreach (Match match in regex.Matches(Output))
            {
                resultList.Add(match.Groups[1].ToString());
            }
            textBox4.Text = string.Join(", ", resultList);
            System.Threading.Thread.Sleep(500);
            for (int i = 0; i < resultList.Count; i++)
            {
                Process cmd2 = new Process();
                cmd2.StartInfo.FileName = "netsh.exe";
                System.Threading.Thread.Sleep(50);
                cmd2.StartInfo.Arguments = "wlan show profiles name=" + resultList[i] + " key=clear";
                cmd2.StartInfo.UseShellExecute = false;
                cmd2.StartInfo.RedirectStandardOutput = true;
                cmd2.StartInfo.RedirectStandardError = true;
                cmd2.Start();
                //* Read the output (or the error)
                string output2 = cmd2.StandardOutput.ReadToEnd();
                textBox5.Text = output2;
                cmd2.WaitForExit();
            }
    }
