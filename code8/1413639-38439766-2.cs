    FragmentTransaction tx = FragmentManager.BeginTransaction ();
    tx.Replace (Resource.Id.fragmentContainer, new FirstFrag ());
    tx.Commit(); //Where fragmentContainer is your FrameLayout.
    //Also note that tx.Replace is acting like tx.Add if there is no fragment.
    
