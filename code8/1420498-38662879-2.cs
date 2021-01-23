    for (int c = 0; c <= p.W; c++) //since its a 0-1 MKP problem so initialize whole array with zeroes
    {
        V[0, c] = 0;
    }
    for (int r = 0; r <= N; r++)
    {
         V[r, 0] = 0;
    }
