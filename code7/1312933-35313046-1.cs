        using System;
        using System.Collections.Generic;
        namespace ConsoleApplication1
        {
            class Item
            {
                public Item(int column1, int column2)
                {
                    Column1 = column1;
                    Column2 = column2;
                }
                public int Column1;
                public int Column2;
                public override string ToString()
                {
                    return $"[{Column1}, {Column2}]";
                }
            }
            class Program
            {
                static void Main()
                {
                    List<Item> items = new List<Item>
                    {
                        new Item(1, 72),
                        new Item(2, 29),
                        new Item(2, 30),
                        new Item(3, 27),
                        new Item(3, 38),
                        new Item(3, 53),
                        new Item(4, 72),
                        new Item(4, 21),
                        new Item(4, 86),
                        new Item(4, 17),
                        new Item(5, 90)
                    };
                    SortSubgroupsBy(items, (x, y) => x.Column1 == y.Column1, (x, y) => y.Column2 - x.Column2);
                    Console.WriteLine(string.Join("\n", items));
                }
                public static void SortSubgroupsBy<T>
                (
                    List<T> items, 
                    Func<T, T, bool> sortedColumnComparer,  // Used to compare the already-sorted column.
                    Func<T, T, int>  unsortedColumnComparer // Used to compare the unsorted column.
                )
                {
                    var unsortedComparer = Comparer<T>.Create(
                        (x, y) => unsortedColumnComparer(x, y));
                    for (int i = 0; i < items.Count; ++i)
                    {
                        int j = i + 1;
                        while (j < items.Count && sortedColumnComparer(items[i], items[j]))
                            ++j;
                        if ((j - i) > 1)
                            items.Sort(i, j-i, unsortedComparer);
                    }
                }
            }
        }
