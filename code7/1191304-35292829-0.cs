    var caliburnBind = ViewModelBinder.Bind;
    ViewModelBinder.Bind = (viewModel, view, context) =>
        {
            MyBinder.AddCustomBinding(viewModel, view);
            caliburnBind(viewModel, view, context);
        };
