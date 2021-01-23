    private void mapMouseUp(object sender, MouseEventArgs e) {
        Rectangle rect1 = new Rectangle(0, 0, 100, 100);
        Rectangle rect2 = new Rectangle(0, 100, 100, 100);
        if (rect1.Contains(e.Location)) {
            // Do your stuff
        } else if (rect2.Contains(e.Location)) {
            // Do your stuff
        }
    }
