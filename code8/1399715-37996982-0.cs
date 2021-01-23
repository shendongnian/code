    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            var mainVm = new MainViewModel();
            mainVm.GetStatuses();
            mainVm.GetMro();
            Console.WriteLine("Status: {0} {1}", mainVm.StatusVm.Name, mainVm.StatusVm.CreateDate);
            Console.WriteLine("MroVm: {0} {1}", mainVm.MroVm.Name, mainVm.MroVm.CreateDate);
        }
    }
    public class MainViewModel
    {
        public StatusViewModel StatusVm { get; set; }
        public MroViewModel MroVm { get; set; }
        public void GetStatuses()
        {
            var result =  Get(VmKind.Status);
            StatusVm = result.SingleOrDefault(c => c.StatusId.Equals(-1)) as StatusViewModel;
        }
        public void GetMro()
        {
            var result = Get(VmKind.Mro);
            MroVm = result.SingleOrDefault(c => c.StatusId.Equals(-1)) as MroViewModel;
        }
        public IEnumerable<IVm> Get(VmKind vmKind)
        {
            var dataService = new MyDataService();
            return dataService.Get(vmKind);
        }
    }
    public interface IVm
    {
        int StatusId { get; set; }
        DateTime CreateDate { get; set; }
        string Name { get; }
    }
    public class StatusViewModel : IVm
    {
        public DateTime CreateDate { get; set; }
        public int StatusId { get; set; }
        public string Name { get { return "StatusViewModel"; } }
    }
    public class MroViewModel : IVm
    {
        public DateTime CreateDate { get; set; }
        public int StatusId { get; set; }
        public string Name { get { return "MroViewModel"; } }
    }
    public enum VmKind
    {
        Status,
        Mro
    }
    #region Strategy
    public interface IDataGetter
    {
        IEnumerable<IVm> Get(VmKind vmKind);
    }
    public class MyDataService : IDataGetter {
        public IEnumerable<IVm> Get(VmKind vmKind)
        {
            switch (vmKind)
            {
                case VmKind.Status:
                    return GetStatuses();
                    //break;
                case VmKind.Mro:
                    return GetMro();
                    //break;
                default:
                    throw new ArgumentException("Unknown VM type");
            }
        }
        private IEnumerable<IVm> GetMro()
        {
            return new List<MroViewModel> {
                new MroViewModel { StatusId = -1, CreateDate = DateTime.Now },
                new MroViewModel { StatusId = 2, CreateDate = DateTime.Now }
            };
        }
        private IEnumerable<StatusViewModel> GetStatuses()
        {
            return new List<StatusViewModel> {
                new StatusViewModel { StatusId = -1, CreateDate = DateTime.Now },
                new StatusViewModel { StatusId = 2, CreateDate = DateTime.Now }
            };
        }
    }
    #endregion
    #region Factory
    public class VmFactory {
        static IVm Create(VmKind vmKind)
        {
            IVm result = null;
            switch (vmKind)
            {
                case VmKind.Status:
                    result = new StatusViewModel { StatusId = -1, CreateDate = DateTime.Now };
                    break;
                case VmKind.Mro:
                    result = new MroViewModel { StatusId = -1, CreateDate = DateTime.Now };
                    break;
                default:
                    throw new ArgumentException("Unknown VM type");
                    //break;
            }
            return result;
        }
    }
    #endregion
