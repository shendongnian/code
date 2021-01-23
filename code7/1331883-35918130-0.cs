    public new object SelectedValue
    {
        get
        {
            return base.SelectedValue;
            
        }
        set
        {
            if (!DesignMode)
            {
                if (!_listInitialized)
                {
                    var bindingSource = DataSource as BindingSource;
                    if (bindingSource != null)
                    {
                        var t = (bindingSource.DataSource as Type);
                        var rst = ...///how you get your type list
                        if (rst != null)
                        {
                            bindingSource.DataSource = rst;
                            _listInitialized = true;
                        }
                    }
                }
                else
                {
                    base.SelectedValue = value;
                }
            }
        }
    }
