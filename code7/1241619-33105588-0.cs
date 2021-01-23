        private async void button1_Click(object sender, EventArgs e)
        {
            // START PROGRESS BAR MOVEMENT:
            button1.Enabled = false;
            pb.Style = ProgressBarStyle.Marquee;
            pb.Show();
            // DO THE WORK ON A DIFFERENT THREAD:
            await (Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000); // simulated work (remove this and uncomment the two lines below)
                //LoadDatabase.Groups();
                //ProcessResults.GroupOne();
            }));
            
            // END PROGRESS BAR MOVEMENT:
            pb.Hide();
            button1.Enabled = true;
        }
