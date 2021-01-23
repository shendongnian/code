protected override void OnLoad(EventArgs e)
 {
  this.Visible = false;
   this.Opacity = 1;
   AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND);
 base.OnLoad(e);
  }
