    BindingSource bs = new BindingSource();
    bs.DataSource = niches_list.LIST_niches
    cbo1.DisplayMember = "LIST_niches";             
    cbo1.DataSource = bs;
    BindingSource bs2 = new BindingSource();
    bs2.DataSource = niches_list.LIST_niches;
    cbo2.DisplayMember = "LIST_niches";             
    cbo2.DataSource = bs2;
