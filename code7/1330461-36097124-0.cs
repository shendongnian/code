        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        [Browsable(false)]
        public object Address
        {
            get { return bindingSource.DataSource; }
            set 
            {
                if (value != null && value != System.DBNull.Value)
                    bindingSource.DataSource = value;
                else
                    bindingSource.DataSource = typeof(AddressDto);
            }
        }
