    double[,] sin_in = new double[1, 360];
    double[,] sin_out = new double[1, 360];
    double deg = 0.0;
    const double dtor = 3.141592654 / 180.0;
    
    for (int i = 0; i < 360; i++)
    {
        sin_out[0,i] =  Math.Sin(deg * dtor); // complains I need to use new
        sin_in[0,i] = deg / 360.0; //When I use new I get another error
        deg += 1.0;
    }
