    private void MoveW() {
        if (YourCube.Top > 0) {
            YourCube.Location = new Point(YourCube.Left, YourCube.Top -1);
        }
    }
    
    private void MoveA() {
        if (YourCube.Left > 0) {
            YourCube.Location = new Point(YourCube.Left - 1, YourCube.Top);
        }
    }
    
    private void MoveS() {
        if (YourCube.Top + YourCube.Height < form1.ClientRectangle.Height) {
            YourCube.Location = new Point(YourCube.Left, YourCube.Top + 1);
        }
    }
    
    private void MoveD() {
        if (YourCube.Left + YourCube.Width < form1.ClientRectangle.Width) {
            YourCube.Location = new Point(YourCube.Left + 1, YourCube.Top);
        }
    }
