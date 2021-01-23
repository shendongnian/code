    for (int i = 1; i < 5; i++)
    {
        double[] newVector = RotateVector2d(points[i - 1, 0], points[i - 1, 1], 2.0*Math.PI/5);   // degrees in rad !
        points[i, 0] = newVector[0];
        points[i, 1] = newVector[1];
        Debug.WriteLine(newVector[0] + " " + newVector[1]);
    }
