        public class Task
        {
            private ViewModel viewModel;
            public class Task(ViewModel viewModel)
            {
                this.viewModel = viewModel;
            }
            ...
        }
    However, this makes Task class usable only with ViewModel class, because they are loosely coupled.
