    var validationMessages = new[]{new{Control = InnerpathTextBox, 
                                       Message = "Please Enter Internal Path"},
                                   new{Control = InspectorIDTextBox, 
                                       Message = "Please Enter Inspector Id"},
                                   //etc
    };
    foreach(var vm in validationMessages)
    {
        if(string.IsNullOrWhiteSpace(vm.Control.Text))
        {
            MessageBox.Show(vm.Message);
            this.ActiveControl = vm.Control;
            break;
        }
    }
