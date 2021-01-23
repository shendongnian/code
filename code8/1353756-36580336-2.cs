        public ViewOrderViewModel GetViewModel(Order orderObject)
        {
            ViewOrderViewModel viewModel = new ViewOrderViewModel();
            viewModel.OrderId = orderObject.OrderId;
            viewModel.FirstName = orderObject.FirstName;
            // etc...
            return viewModel;
        }
