    public class Controller
    {
        public static FirstReadViewModel getNewFirstReadViewModel()
        {
            var dal = new DataLayer();
            var vm = new FirstReadViewModel(dal);
            return vm;
        }
    }
