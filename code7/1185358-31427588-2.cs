        private void button1_Click(object sender, EventArgs e) {
            var form = new Form2();
            form.Load += CenterOnSecondMonitor;
            form.Show();
        }
        private void CenterOnSecondMonitor(object sender, EventArgs e) {
            var form = (Form)sender;
            var area = Screen.AllScreens.Length > 1 ? Screen.AllScreens[1].WorkingArea : Screen.PrimaryScreen.WorkingArea;
            form.Location = new Point((area.Width - form.Width) / 2, (area.Height - form.Height) / 2);
            form.Load -= CenterOnSecondMonitor;
        }
