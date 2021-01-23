     byte[] arr = new byte[] { 51, 51, 46, 56};
     double res = 0, floatindex = 0.1;
     bool isLessThanZero = false;
     for (int i = 0; i < arr.Length; i++)
     {
        if (arr[i] == 46)
        {
            isLessThanZero = true;
            continue;
        }
        if (!isLessThanZero)
            res = 10*res + arr[i] - 48;
        else
        {
            res += (arr[i] - 48)*floatindex;
            floatindex /= 10.0;
        }
    }
    return res;
