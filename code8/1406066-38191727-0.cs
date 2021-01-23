    async void loadProfiles ()
    {
        var getTheInfo = await phpApi.getProfileFromID (theId); //i gather the rest of the info connected with the correct ID.
        // store only newly added images this cycle
        List<Tuple<string, string>> newImages = new List<Tuple<string, string>>();
        foreach (var item in getTheInfo["results"]) /i loop the correct info out from the ID
        {
            // append to newImages instead of imagesList
            newImages.Add (
                Tuple.Create(
                    item ["Photo"].ToString (),
                    item ["Name"].ToString ()
                )
            );
        }
        // loop through newImages instead of imagesList
        foreach (var img in newImages ) {
            var inner = new StackLayout ();
            var image = new CircleImage ();
            image.Source = img.Item1;
            var button = new Button ();
            button.Text = img.Item2;
            inner.Children.Add (image);
            inner.Children.Add (button);
            myStackLayout.Children.Add (inner);
        }
        // add newImages to imagesList
        imagesList.AddRange(newImages);
    }
