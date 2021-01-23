    public class ImagePage : ContentPage
    {
    
        //view holding the image
		LRMasterDetailPage imageView;
		//collection of images using the photo.Url
		ObservableCollection<Image> images;
		//current image index
		int index = 0;
    public ImagePage(){
    
           images = new ObservableCollection<Image> ();
           imageView = new LRMasterDetailPage {
				Content = this.images [index]
			};
			this.Content = imageView;
    }
     //Subscribe to the swipeLeft and swipeRight message
      protected override void OnAppearing ()
		{
			base.OnAppearing ();
			MessagingCenter.Subscribe <string> (this,"LeftSwipe", (sender) => {
				//Do something
				if(index < images.Count-1){
					index++;
				}
				imageView.Content = this.images[index];
				
			});
			MessagingCenter.Subscribe <string> (this, "RightSwipe", (sender) => {
				//Do something
				if(index > 0){
					index--;
				}
				imageView.Content = this.images[index];
			});
       }
         protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //this._image = null;
			images = null;
			MessagingCenter.Unsubscribe<string>(this,"LeftSwipe");
			MessagingCenter.Unsubscribe<string>(this, "RightSwipe");
			MessagingCenter.Unsubscribe<string>(this, "LongPress");
            //GC.Collect();
        }
    }
