    private void OnMouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.MouseDown -= MethodOnMouseDown;
      this.MouseMove -= MethodOnMouseMove;
    
      // Do something.....
    
      this.MouseDown += MethodOnMouseDown;
      this.MouseMove += MethodOnMouseMove;
    }
