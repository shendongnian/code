    public RelayCommand ApplyChangesCommand { get; set; }
        public void ApplyChangesCommandAction(object param)
        {
            foreach (var item in (param as List<BindingExpression>))
            {
                item.UpdateSource();
            }
        }
