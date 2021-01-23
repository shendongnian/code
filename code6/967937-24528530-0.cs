    public interface IReportParams {
        IEnumerable<StatusEnum> SelectedStatuses { get; }
    }
    public class WpfReportParams : IReportParams {
        private readonly ObservableCollection<StatusEnum> _SelectedStatuses;
        public WpfReportParams() {
            _SelectedStatuses = new ObservableCollection<StatusEnum>();
        }
        public ICollection<StatusEnum> SelectedStatuses {
            get { return _SelectedStatuses; }
        }
        IEnumerable<StatusEnum> IReportParams.SelectedStatuses {
            get { return SelectedStatuses; }
        }
    }
