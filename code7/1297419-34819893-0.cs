    intensity = sqrt(R*R + G*G + B*B)
    if(intensity != 0)
    {
        R = R / intensity;
        G = G / intensity;
        B = B / intensity;
    }
