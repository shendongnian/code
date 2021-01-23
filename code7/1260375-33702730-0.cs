    public class StateInfo
    {
        static StateInfo()
        {
            lst.Add("Alabama");
            lst.Add("Alaska");
            lst.Add("Arizona");
            ...
        }
        static readonly List<string> _lst = new List<string>();
        static readonly object _listLock = new object();
        static int _nextIndex = 0;
        public static string GetNextState()
        {
            int i = 0;
            lock(_listLock)
            {
                i = _nextIndex;
                _nextIndex = (_nextIndex + 1) % _lst.Count;                
            }
            return _lst[i];
        }
    }
