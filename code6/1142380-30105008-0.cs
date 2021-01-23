    static string[,] RemoveNotNullRow(string[,] o)
    {
        var rowLen = o.GetUpperBound(1) + 1;
        var notNullRowIndex = (from oo in o.Cast<string>().Select((x, idx) => new { idx, x })
                    group oo.x by oo.idx / rowLen into g
                    where g.Any(f => f != null)
                    select g.Key).ToArray();
        var res = new string[notNullRowIndex.Length, rowLen];
        for (int i = 0; i < notNullRowIndex.Length; i++)
        {
            Array.Copy(o, notNullRowIndex[i] * rowLen, res, i * rowLen, rowLen);
        }
        return res;
    }
