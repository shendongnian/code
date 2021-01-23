    public class PhotoPage {
        public PhotoPage() {
            //imagesListview.ItemSelected += selectedItemClick;
            //loadPhotos ();
        }
        protected override async void OnAppearing() {
            await loadPhotos();
        }
        ....
    }
