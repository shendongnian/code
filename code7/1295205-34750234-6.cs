        var newvnode = new VNode();
        newvnode.PropertyChanged += (s,e) => {
            if (e.PropertyName == "IsSelected") {
                OnPropertyChanged("SelectedVNodes");
            }
        };
        //  blah blah blah much else blah blah
        public IEnumerable<VNode> SelectedVNodes {
            get { return VNodes.Where(vn => vn.IsSelected); }
        }
