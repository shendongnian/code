    SubClass1Objs= new ObservableCollection<SubClass1>();
        if (objs != null)
            foreach (BaseClass obj in objs.Where(c => c.GetType() == typeof(SubClass1)))
                SubClass1Objs.Add((SubClass1)card);;
    SubClass1Objs.CollectionChanged += SubClass1Objs_CollectionChanged;
