        var vm = new RecyclerViewModel();
        var fragments = new List<MvxFragmentPagerAdapter.FragmentInfo>();
        for(int i = 0; i < vm.Items.Count; i++)
        {
            fragments.Add(new MvxFragmentPagerAdapter.FragmentInfo("RecyclerView " + (i+1).ToString(), typeof (RecyclerViewFragment),typeof (RecyclerViewModel)));
        }
        viewPager.Adapter = new MvxFragmentPagerAdapter(Activity, ChildFragmentManager, fragments);
