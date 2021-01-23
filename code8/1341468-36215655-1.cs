     private RelayCommand<BaseProduct> _CheckBoxChecked;
        public RelayCommand<BaseProduct> CheckBoxChecked
        {
            get { return _CheckBoxChecked??(_CheckBoxChecked=new RelayCommand<BaseProduct>(CheckMethod)); }
            set { _CheckBoxChecked = value; }
        }
        void CheckMethod(BaseProduct product)
        {
          // you can access product here 
        }
  
