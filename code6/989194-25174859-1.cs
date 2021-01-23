    class X_ViewModel
    { 
        public X Model { get; private set; }
    
        public X_ViewModel(X model)
        {
            Model = model;
        }
      
        string DisplayName 
        {
            get { return string.Format("{0}-{1}-{2}", A, B, C); }
        }
     
        .... 
    
    }
    var l = GetListOfX().Select(x => new X_ViewModel(x)).ToList();
    ComboBox1.DataSource = l;
    ComboBox1.DisplayMember = "DisplayName";
    ComboBox1.ValueMember = "Model";
