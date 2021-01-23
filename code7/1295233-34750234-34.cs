        var newvnode = new VNode();
        newvnode.PropertyChanged += (s,e) => {
            if (e.PropertyName == "IsSelected") {
                //  Make sure OnPropertyChanged("SelectedVNodes") is happening!
                SelectedVNodes = new ObservableCollection<VNode>(
                        VNodes.Where(vn => vn.IsSelected)
                    );
            }
        };
