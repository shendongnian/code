        var newvnode = new VNode();
        newvnode.PropertyChanged += (s,e) => {
            if (e.PropertyName == "IsSelected") {
                if ((bool)e.NewValue) {
                    //  If not in SelectedVNodes, add it.
                } else {
                    //  If in SelectedVNodes, remove it.
                }
            }
        };
        //  blah blah blah
