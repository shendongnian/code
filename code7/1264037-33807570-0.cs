    private void timer_Tick(object sender, EventArgs e)
        {
            var thisTimer = sender as Timer;
            if (thisTimer != null)
            {
                _ticks++;
                this.UpdateLabel(_ticks.ToString());
                if (_ticks == 10)
                {
                    this.UpdateLabel("Done");
                }                
            }
        }
    private void UpdateLabel(string text)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new Action(() => this.UpdateLabel(text));
        }
        else
        {
            this.label1.Text = text;
        }
    }
