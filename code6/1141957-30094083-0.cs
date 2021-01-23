        void tm_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Label1.Invoke((Action)(() =>
            {
                int lbl = Convert.ToInt32(Label1.Text);
                Label1.Text = (lbl+1).ToString();
            }));
        }
