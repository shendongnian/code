        FragmentClass1 Fragment1;
        FragmentClass2 Fragment2;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.detalleVisita);
			Fragment1= new FragmentClass1();
			Fragment2= new FragmentClass2();
			Spinner spinner = this.FindViewById<Spinner>Resource.Id.spinner);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
		}
        void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            int selectedSpinn = e.Position;
            if(selectedSpinn ==0)
            {
                 //THAT DOES THE CHANGE OF FRAGMENT
                 FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();
			     fragmentTx.Replace(Resource.Id.spinner_fragment, Fragment1);
			     fragmentTx.SetTransition (FragmentTransit.FragmentFade);
			     fragmentTx.Commit();
            }
            else if(selectedSpinn ==1)
            {
                 //THAT DOES THE CHANGE OF FRAGMENT
                 FragmentTransaction fragmentTx =  this.FragmentManager.BeginTransaction();
			     fragmentTx.Replace(Resource.Id.spinner_fragment, Fragment2);
			     fragmentTx.SetTransition (FragmentTransit.FragmentFade);
			     fragmentTx.Commit();
            }
        }
