    	private void Display (){
			LinearLayout display2 = FindViewById<LinearLayout> (Resource.Id.linearLayout12);		
			//LinearLayout display = FindViewById<LinearLayout> (Resource.Id.linearLayout13);			
			TextView productname = FindViewById<TextView> (Resource.Id.posttittle);
			TextView price = FindViewById<TextView> (Resource.Id.price);
			TextView weight = FindViewById<TextView> (Resource.Id.weight);
			productname.Text = Intent.GetStringExtra ("title");
				
			if (productname.Text == Intent.GetStringExtra ("title")) {
				display2.Visibility = ViewStates.Visible;
			} 
			else {
				display2.Visibility = ViewStates.Gone;
			}
			
			price.Text = Intent.GetStringExtra("price");
			weight.Text = Intent.GetStringExtra("weight");
			//display2.Visibility = ViewStates.Visible;
			productname.Visibility = ViewStates.Visible;
			price.Visibility = ViewStates.Visible;
			weight.Visibility = ViewStates.Visible;
		}
