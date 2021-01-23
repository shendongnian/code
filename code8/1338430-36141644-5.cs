    var resultAngle = 0.0;
    if (quarter_1)
    {
        resultAngle = 0 + angleFromX;
        // same as
        resultAngle = 90 - angleFromY;
    }
    if (quarter_2)
    {
        resultAngle = 90 + angleFromY;
        // same as
        resultAngle = 180 - angleFromX;
    }
    if (quarter_3)
    {
        resultAngle = 180 + angleFromX;
        // same as
        resultAngle = 270 - angleFromY;
    }
    if (quarter_4)
    {
        resultAngle = 270 + angleFromY;
        // same as
        resultAngle = 360 - angleFromX;
    }
