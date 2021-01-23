    public override void OnBeforeFragmentChanging (IMvxCachedFragmentInfo fragmentInfo, Android.Support.V4.App.FragmentTransaction transaction)
    		{
    			var currentFrag = SupportFragmentManager.FindFragmentById (Resource.Id.content_frame) as MvxFragment;
    
    			if(currentFrag != null 
    				&& fragmentInfo.ViewModelType != typeof(MenuViewModel) 
    				&& currentFrag.FindAssociatedViewModelType() != fragmentInfo.ViewModelType)
    				fragmentInfo.AddToBackStack = true;
    			base.OnBeforeFragmentChanging (fragmentInfo, transaction);
    		}
