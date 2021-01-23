        if (DataContext is ViewModelA)
        {
            var _vm = (ViewModelA)DataContext;
            _vm.DoViewModelAMethod();
            _vm.Property1 = "abc";
        }
        else if (DataContext is ViewModelB)
        {
            var _vm = (ViewModelB)DataContext;
            _vm.DoViewModelBMethod();
            _vm.Property1 = "abc";
        }
        //etc. etc.
