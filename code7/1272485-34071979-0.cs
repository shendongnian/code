    private void keyboardHandler(object sender, KeyPressEventArgs e){
      char keyPressed = e.KeyChar;
      if (keyPressed >= (char)Keys.D0 && keyPressed <= (char)Keys.D9)
      {
        //Some stuff
      }
      else if (keyPressed == (char)Keys.Back)
      {
        //More stuff
      }
      else if (keyPressed == (char)Keys.Enter || keyPressed == (char)Keys.Return)
      {
        this.operate();
        operator = operation.START;
        e.Handled = true;
      }
    } 
