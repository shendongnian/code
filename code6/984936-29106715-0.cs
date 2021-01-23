    protected void ebAudiofileSeekerEnterNotifyEvent (object o, EnterNotifyEventArgs args)
        {
            log.debug("ebAudiofileSeekerEnterNotifyEvent called");
            if (Program.getInstance().getAudioManager().Duration > TimeSpan.Zero)
            {
                int x = -1;
                int y = -1;
                int intX = -1;
                int intY = -1;
                int originX;
                int originY;
                this.GetPosition(out originX, out originY);
                Gdk.ModifierType modifierType = Gdk.ModifierType.None;
                this.Screen.RootWindow.GetPointer(out x, out y, out modifierType);
                this.hsAudiofileSeeker.TranslateCoordinates(this, this.hsAudiofileSeeker.Allocation.X, this.hsAudiofileSeeker.Allocation.Y, out intX, out intY);
                double valueAtPos = ((x - (intX + originX)) / (this.hsAudiofileSeeker.Allocation.Width * 1.0)) * this.hsAudiofileSeeker.Adjustment.Upper * 1.0;
                long ticksAtPosition = (Program.getInstance().getAudioManager().Duration.Ticks * (long)valueAtPos) / 100;
                TimeSpan timeSpanAtPosition = TimeSpan.FromTicks(ticksAtPosition);
                this.lblTooltipAudiofileSeeker.Text = (timeSpanAtPosition.Hours > 9 ? timeSpanAtPosition.Hours.ToString() : "0" + timeSpanAtPosition.Hours.ToString()) + ":" + (timeSpanAtPosition.Minutes > 9 ? timeSpanAtPosition.Minutes.ToString() : "0" + timeSpanAtPosition.Minutes.ToString()) + ":" + (timeSpanAtPosition.Seconds > 9 ? timeSpanAtPosition.Seconds.ToString() : "0" + timeSpanAtPosition.Seconds.ToString());
                this.hsAudiofileSeeker.TooltipWindow.Move(x, intY + originY);
                this.hsAudiofileSeeker.TooltipWindow.ShowAll();
            }
        }
    protected void ebAudiofileSeekerMotionNotifyEvent (object o, MotionNotifyEventArgs args)
    {
        log.debug("ebAudiofileSeekerMotionNotifyEvent called");
        if (Program.getInstance().getAudioManager().Duration > TimeSpan.Zero)
        {
            int x = -1;
            int y = -1;
            int intX = -1;
            int intY = -1;
            int originX;
            int originY;
            this.GetPosition(out originX, out originY);
            Gdk.ModifierType modifierType = Gdk.ModifierType.None;
            this.Screen.RootWindow.GetPointer(out x, out y, out modifierType);
            this.hsAudiofileSeeker.TranslateCoordinates(this, this.hsAudiofileSeeker.Allocation.X, this.hsAudiofileSeeker.Allocation.Y, out intX, out intY);
            double valueAtPos = ((x - (intX + originX)) / (this.hsAudiofileSeeker.Allocation.Width * 1.0)) * this.hsAudiofileSeeker.Adjustment.Upper * 1.0;
            log.debug("modifier = " + modifierType);
            if (modifierType.HasFlag(Gdk.ModifierType.Button1Mask))
            {
                log.debug("modifier is button 1, so change value");
                this.hsAudiofileSeeker.Value = valueAtPos;
            }
            long ticksAtPosition = (Program.getInstance().getAudioManager().Duration.Ticks * (long)valueAtPos) / 100;
            TimeSpan timeSpanAtPosition = TimeSpan.FromTicks(ticksAtPosition);
            this.lblTooltipAudiofileSeeker.Text = (timeSpanAtPosition.Hours > 9 ? timeSpanAtPosition.Hours.ToString() : "0" + timeSpanAtPosition.Hours.ToString()) + ":" + (timeSpanAtPosition.Minutes > 9 ? timeSpanAtPosition.Minutes.ToString() : "0" + timeSpanAtPosition.Minutes.ToString()) + ":" + (timeSpanAtPosition.Seconds > 9 ? timeSpanAtPosition.Seconds.ToString() : "0" + timeSpanAtPosition.Seconds.ToString());
            this.hsAudiofileSeeker.TooltipWindow.Move(x, intY + originY);
        }
    }
    protected void ebAudiofileSeekerLeaveNotifyEvent (object o, LeaveNotifyEventArgs args)
    {
        log.debug("ebAudiofileSeekerLeaveNotifyEvent called");
        this.hsAudiofileSeeker.TooltipWindow.HideAll();
    }
