    public class ThreadWorker<T>
    {
        SemaphoreSlim _sem = null;
        List<T> _lst;
            
        public ThreadWorker(List<T> lst, int maxThreadCount)
        {
            _lst = lst;
            _sem = new SemaphoreSlim(maxThreadCount);
        }
        public void Start()
        {
            var i = 0;
            while (i < _lst.Count)
            {
                i++;
                var pull = _lst[i];
                _sem.Wait(); /*****/
                Process(pull);
            }
        }
        public void Process(T item)
        {
            var t = new Thread(() => Opration(item));
            t.Start();
        }
        public void Opration(T item)
        {
            Console.WriteLine(item.ToString());
            _sem.Release(); /*****/
        }
    }
