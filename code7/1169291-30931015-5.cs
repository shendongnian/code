    public class ConcreteView : IView {
        private Button btn
        private Grid grid;
        private Presenter presenter = new Presenter();        
        public ConcreteView() {
            presenter.View = this;
            btn.Click += (s, a) => presenter.LoadData();
        }
        public void DisplayItems(IEnumerable<Item> items) {
            // enumerate the items and add them to your grid...
        }
    }
