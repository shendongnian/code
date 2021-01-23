    using System.Collections.ObjectModel;
    using WpfApplication1.Helper;
    using WpfApplication1.Model;
    namespace WpfApplication1
    {
        public class MainWindowViewModel : NotifyBase
        {
            public ObservableCollection<Customer> Customers { get; } = new ObservableCollection<Customer>();
        }
    }
