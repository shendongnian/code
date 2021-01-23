    protected override void OnMouseEnter(MouseEventArgs e)
    {
      base.OnMouseEnter(e);
      var Pos = e.GetPosition(this);
      PART_EW.Margin = new Thickness(
                           Pos.X - PART_EW.Width / 2, 
                           Pos.Y - PART_EW.Height / 2, 
                           -PART_EW.Width, 
                           -PART_EW.Height);
      PART_EW.Visibility = Visibility.Visible;
    }
    protected override void OnMouseLeave(MouseEventArgs e)
    {
      base.OnMouseLeave(e);
      PART_EW.Visibility = Visibility.Collapsed;
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      var Pos = e.GetPosition(designerItem);
      PART_EW.Margin = new Thickness(
                           Pos.X - PART_EW.Width / 2, 
                           Pos.Y - PART_EW.Height / 2, 
                           -PART_EW.Width, 
                           -PART_EW.Height);
    }
