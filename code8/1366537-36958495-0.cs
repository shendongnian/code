    foreach (Control ctl_loopVariable in new Control[] { gbGrbl, gbJogging, gbGcode})
    {
        ctl = ctl_loopVariable;              	
  		ctl.Location = new Point(3, ctl.Location.Y);
    }
