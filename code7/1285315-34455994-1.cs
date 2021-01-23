    public class ProcessDiff : IEqualityComparer<Process>
    {
        public IEnumerable<Process> GetDiff(IEnumerable<Process> oldProcesses, IEnumerable<Process> newProcesses )
        {
            return newProcesses.Except(oldProcesses, this);
        }
        public bool Equals(Process x, Process y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return x.Id == y.Id;
        }
        public int GetHashCode(Process obj)
        {
            if (obj == null) return 0;
            return obj.Id;
        }
    }
