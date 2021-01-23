    IGalleryImageService galleryService = Xamarin.Forms.DependencyService.Get<IGalleryImageService>();
                galleryService.ImageSelected += (o, imageSourceEventArgs) =>
                {      
                    ActiveParking.CarImageBindable = imageSourceEventArgs.ImageSource.ToString();
                    (ActiveParking.Page as PageTemplate).CarImage.Source = galleryService.GetImage(imageSourceEventArgs.ImageSource.ToString());
    
                };
                galleryService.SelectImage();
