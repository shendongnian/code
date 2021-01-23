    public class TestViewModel : BindableBase
    {
        private String _UpdatePer = Overall.PercentageDwnd.ToString();
        public String UpdatePercentage
        {
            get { return _UpdatePer; }
            set { SetProperty(ref _UpdatePer, value); }
        }
        public TestViewModel(tblTransaction model)
        {
            Overall.PercentageDwndChanged += Overall_PercentageDwndChanged;
            // TODO: Complete member initialization
        }
        private void Overall_PercentageDwndChanged(object sender, EventArgs e)
        {
            this.UpdatePercentage = Overall.PercentageDwnd.ToString();
        }
    }
