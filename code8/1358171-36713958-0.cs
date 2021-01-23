    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
       base.OnActivityResult(requestCode, resultCode, data);
       _imageView = FindViewById<ImageView> (Resource.Id.imageView1);
    
       if (resultCode == Result.Ok)
       ...
   	   else if ((requestCode == SELECT_FILE) && (data != null))
	   {
			var _imageView = FindViewById<ImageView> (Resource.Id.imageView1);
			_imageView.SetImageURI(data.Data);
	   }
         
