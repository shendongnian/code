    public void OnMouseMove(object sender, MouseEventArgs e)
    {
        //Create a variable to hold the Point value of the current Location
        Point pt = new Point(e.Location);
        //Retrieve the index of the ListBox item at the current location. 
	    int CurrentItemIndex = lstPosts.IndexFromPoint(pt);
    }
