    public class Presenter {
        // Repository class used to retrieve data
        private IRepository<Item> repository = ...;
        public void View { get; set; }
        public void LoadData() {
            // Retrieve your data from a repository or service
            IEnumerable<Item> items = repository.find(...);
            this.View.DisplayItems(items);
        }
    }
    public interface IView {
        void DisplayItems(IEnumerable<Item> items);
    }
