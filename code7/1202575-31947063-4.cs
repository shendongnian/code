    using System.Collections.Generic;
    using System.Linq;
    var bRows = Enumerable.Range(0, arr.m)
        .Select(i => b.YieldRow(i).ToList())
        .ToList();
    var test = Enumerable.Range(0, arr.m)
        .Select(i => a.YieldRow(i))
        .All(aRow => bRows.Any(bRow => aRow.SequenceEqual(bRow)); 
    if (test)
    {
        MessageBox.Show("two graphs are different ");
    }
    // ...
    public static class Ext
    {
        // This is fine for your special case but remember,
        // MD Arrays don't necessarily have a lower bound of 0.
        private IEnumerable<T> YieldRow(this T[,] arr, int row)
        {
            for (var i = 0; i < arr.GetLength(1); i++)
            {
                yield return arr[row, i];
            }
        }
    }
