    byte red = oRow[x * pixelSize + 2],
        green = oRow[x * pixelSize + 1],
        blue = oRow[x * pixelSize];
    if (red != 255 || green != 255 || blue != 255)
    {
        nRow[x * pixelSize + 2] = red;
        nRow[x * pixelSize + 1] = green;
        nRow[x * pixelSize] = blue;
    }
