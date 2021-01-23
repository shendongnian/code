        public class PossibleValuesCellComparer : IEqualityComparer<Cell>
        {
            public bool Equals(Cell x, Cell y)
            {
                return Enumerable.SequenceEqual(x.PossibleValues.OrderBy(t => t), y.PossibleValues.OrderBy(t => t));
            }
            public int GetHashCode(Cell cell)
            {
                var list = cell.PossibleValues.OrderBy(t => t);
                unchecked
                {
                    int hash = 19;
                    foreach (var obj in list)
                    {
                        hash = hash * 31 + obj.GetHashCode();
                    }
                    return hash;
                }
            }
        }
         ....
         var g2 = group.GroupBy(x => x, new PossibleValuesCellComparer());
