     int result = 3;
        int resultMinEen = 1;
        int resultMinTwee = 2;
    
    
    
        for (int i = 1; i <= 4000000; i++)
        {
            if (((i % 2) == 0) && (i == resultMinEen + resultMinTwee))
            {
                result += i;
                resultMinTwee = resultMinEen;
                resultMinEen = result;
            }
        }
