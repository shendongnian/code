    //creating the line with 2 points
    line l = new line(
        new point() { x = 0, y = 0 },
        new point() { x = 9, y = 9 }
        );           
    List<line> result = l.SplitLine(3); 
