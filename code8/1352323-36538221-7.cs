        public void AddViewModel(ViewModelBase viewmodel)
        {
            if (ViewModels == null)
                ViewModels = new ObservableCollection<ViewModelBase>();
            var currentVNs = (from vms in ViewModels where vms.InternalName == viewmodel.InternalName select vms).FirstOrDefault();
            if (currentVNs == null)
                ViewModels.Add(viewmodel);
        }
