    private async void c1Button1_Click(object sender, EventArgs e)
    {
        c1Button1.Enabled = false; // avoid multiple clicks
        for ( int i = 0; i < 100; i++)
        {
            c1RadialGauge1.Value = i;
            textBox1.Text = i.ToString();
            textBox1.Update();
            c1Gauge1.Refresh();
            await Task.Delay(100);
        }
        c1Button1.Enabled = true; // allow further clicks
    }
