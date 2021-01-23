        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "...";
            var result = await Task.FromResult(TestFunc(2));
            button1.Text = result.ToString();
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "...";
            var result = await Task.Run(() => TestFunc(2));
            button2.Text = result.ToString();
        }
        private int TestFunc(int x)
        {
            System.Threading.Thread.Sleep(5000);
            return x;
        }
