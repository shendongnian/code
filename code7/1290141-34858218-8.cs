        .....  // Add this to the Window/Page
        public bool DetectingNewItems
        {
            get
            {
                var vm = DataContext as MyViewModel;
                if (vm != null)
                    return vm.MyPropertyOnVM;
                return false;
            }
        }
        .....  
