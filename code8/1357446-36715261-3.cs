    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button.HasFlag(MouseButtons.Left) && dp_ != null)
        {
            float mh = dp_.MarkerSize / 2f;
            double vx = ca_.AxisX.PixelPositionToValue(e.Location.X);
            double vy = ca_.AxisY.PixelPositionToValue(e.Location.Y);
            dp_.SetValueXY(vx, vy);
            SyncAPoint(ca_, s_, dp_);
            chart1.Invalidate();
        }
    }
