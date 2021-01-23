    public class EnemyComparer : IComparer<Enemy>
    {
        int IComparer<Enemy>.Compare(Enemy x, Enemy y)
        {
            return y.Priority.CompareTo(x.Priority); // reverse operand to invert ordering
        }
    }
