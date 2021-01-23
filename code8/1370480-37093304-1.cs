    private void CounterToDate()
            {
                endTime = new DateTime(2016, 10, 21, 0, 0, 0);
                Timer t = new Timer();
                t.Interval = 500;
                t.Tick += new EventHandler(t_Tick);
                TimeSpan ts = endTime.Subtract(DateTime.Now);
                PaintDrawingControl.texttodraw = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
                paintDrawingControl1.Invalidate();
                t.Start();
    
            }
    
            void t_Tick(object sender, EventArgs e)
            {
                TimeSpan ts = endTime.Subtract(DateTime.Now);
                PaintDrawingControl.texttodraw = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
                paintDrawingControl1.Invalidate();
            }
