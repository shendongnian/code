    protected override void OnViewModelSet ()
    {
    		SetContentView (Resource.Layout.TermsPage);
    
    		var set = this.CreateBindingSet<TermsView, TermsViewModel>();
    		set.Bind(FindViewById<Button>(Resource.Id.acceptTermsButton))
    			.For("Click")
    			.To(vm => vm.AcceptTermsCommand);
    		set.Apply();
    }
