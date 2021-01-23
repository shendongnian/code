    public class Class1
    {
        public BindingList<string> BindingList { get; set; }
        private readonly SynchronizationContext _context = SynchronizationContext.Current;
        public Class1()
        {
            BindingList = new BindingList<string>();
        }
        private int _index;
        public void Add()
        {
            var th = new Thread(() =>
            {
                string item = (++_index).ToString();
                _context.Send(o => BindingList.Add(item), null);
            }) { IsBackground = true };
            th.Start();
        }
        public void Remove()
        {
            if (BindingList.Count > 1)
            {
                BindingList.RemoveAt(0);
            }
        }
    }
