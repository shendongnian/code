    public void Foo(){
        var storyBoard = this.Resources["RotateImage"] as Storyboard;
        // Get the storboard's value to get the DoubleAnimation and manipulate it.
        var rotateImageAnimation = (DoubleAnimation)storyBoard.Children.FirstOrDefault();
    }
