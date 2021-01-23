        private Task SomeUIOperation()
        {
            // ui operation
            return Task.Run(() =>
            {
                this.Invoke(new Action(() => this.BackColor = Color.Aquamarine));
                Thread.Sleep(10000);
                this.Invoke(new Action(() => this.BackColor = Color.Gray));
            });
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await SomeUIOperation();
            // some other stuff
        }
