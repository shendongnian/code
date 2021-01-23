    var commonSize = new Size(100, 100);
    var player = new Rectangle(new Point(0,0), commonSize);
    var blockHitBox = new List<Rectangle>
    {
        new Rectangle(new Point(0,150), commonSize), // This one will not collide
        new Rectangle(new Point(0,100), commonSize)  // This one will collide
    };
    bool collision = blockHitBox.Any(item => item.Overlaps(player));
