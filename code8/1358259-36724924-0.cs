    private void OnImageBtnTapped(object sender, EventArgs e)
    {
      var tappedImage = (Label)sender;
      var ImageId = Convert.ToInt32(tappedImage.StyleId);
      Application.Current.Properties["ItemId"] = ImageId;
  
      MessagingCenter.Send(new RedirectClass.OpenRecordingDetails(), RedirectClass.OpenRecordingDetails.Key);
      // check if a handler is assigned
      if (OnImageSelected != null) {
        OnImageSelected(this,new EventArgs(...));
      }
    }
