    <snip>
    sb.Append("\nOutput using Range.Value2\n");
    vals = (object[,])usedRange.Value2; //1-based array
    var format = GetFormat(usedRange);
    sb.Append(ArrayToString(ref vals, format));
    </snip>
    private static object[,] GetFormat(Microsoft.Office.Interop.Excel.Range range)
    {
        var rows = range.Rows.Count;
        var cols = range.Columns.Count;
        object[,] vals = new object[rows, cols];
        for (int r = 1; r <= rows; ++r)
        {
            for (int c = 1; c <= cols; ++c)
            {
                vals[r-1, c-1] = range[r, c].NumberFormat;
            }
        }
        return vals;
    }
    private static string ArrayToString(ref object[,] vals, object[,] numberformat = null)
    {
        int dim1Start = vals.GetLowerBound(0); //Excel Interop will return index-1 based arrays instead of index-0 based
        int dim1End = vals.GetUpperBound(0);
        int dim2Start = vals.GetLowerBound(1);
        int dim2End = vals.GetUpperBound(1);
        var sb = new StringBuilder();
        for (int i = dim1Start; i <= dim1End; i++)
       {
            for (int j = dim2Start; j <= dim2End; j++)
            {
                if (numberformat != null)
                {
                    var format = numberformat[i-1, j-1].ToString();
                    double v;
                    if (double.TryParse(vals[i, j].ToString(), out v))
                    {
                        if (format.Contains(@"/") || format.Contains(":"))
                        {// parse a date
                            var date = DateTime.FromOADate(v);
                            sb.Append(date.ToString(format));
                        }
                        else
                        {
                            sb.Append(v.ToString(format));
                        }
                    }
                    else
                    {
                        sb.Append(vals[i, j].ToString());
                    }
                }
                else
                {
                    sb.Append(vals[i, j]);
                }
                if (j != dim2End)
                    sb.Append("\t");
            }
            sb.Append("\n");
        }
        return sb.ToString();
    }
