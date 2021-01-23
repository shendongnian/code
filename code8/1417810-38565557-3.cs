    IGalleryImageService galleryService = Xamarin.Forms.DependencyService.Get<IGalleryImageService>();
                galleryService.ImageSelected += (o, imageSourceEventArgs) =>
                {
                    ActiveParking.CImageBindable = Convert.ToBase64String(imageSourceEventArgs.ImageSource);
                    MemoryStream st = new MemoryStream(imageSourceEventArgs.ImageSource);
                    ImageSource imgSource = ImageSource.FromStream(() => st);
                    (ActiveParking.Page as PTemplate).CImage.Source = imgSource;
                };
                galleryService.SelectImage();
