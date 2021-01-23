    data.Sort((x, y) =>
    {
    int result = DateTime.Compare((DateTime)x.Column1, (DateTime)y.Column1);
    if (result == 0)
        result = string.Compare((string)x.Column2, (string)y.Column2);
    if (result == 0)
        result = string.Compare((string)x.Column3, (string)y.Column3);
    if (result == 0)
        {
            long r = (long)x.Column15 - (long)y.Column15;
            result = r == 0 ? 0 : r < 0 ? -1 : 1;
        }
    return result;
    });
