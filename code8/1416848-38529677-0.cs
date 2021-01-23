        private async void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Green;
            var newIp = await GetIpAsync();
            if (oldIp != newIp)
                pictureBox1.BackColor = Color.Red;
        }
        private async Task<string> GetIpAsync()
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(@"https://api.ipify.org");
            }
        }
