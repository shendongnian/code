    private void RegisterBinding(Control control, string controlPropertyName, ViewModel _model, string modelPropertyName)
     {
         control.DataBindings.Add(controlPropertyName, _model, modelPropertyName, true, DataSourceUpdateMode.OnPropertyChanged);
                BindableControls[control.Name] = control;
     }
