        public void Initialize(MyVMClass myVM)
        {
            MyVM = myVM;
            MyVM.PropertyChanged += MyVM_PropertyChanged;
            MyVM_PropertyChanged();
        }
        private void MyVM_PropertyChanged(object sender=null, PropertyChangedEventArgs e=null)
        {
            if (e == null || e.PropertyName == nameof(MyVMClass.CurrentSelection))
            {
                MyBindingSource.DataSource = MyVM.CurrentSelection.ListOfEntries;
            }
        }
