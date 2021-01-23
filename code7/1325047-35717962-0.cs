    ScrollView ScrollView1 = (ScrollView)FindViewById(Resource.Id.ScrollView1);
                ScrollView1.ScrollChange += ScrollView1_ScrollChange;
     
     private void OnScrolled(object sender, EventArgs e)
            {
                ScrollView scrollView = sender as ScrollView;
     
                double scrollingSpace = scrollView.GetChildAt(0).Height - scrollView.Height;
     
                if (scrollingSpace <= scrollView.ScrollY) // Touched bottom
                {
                    // Do the things you want to do
                    Toast.MakeText(this, "You have reached to the bottom!", ToastLength.Short).Show();
                }
            }
