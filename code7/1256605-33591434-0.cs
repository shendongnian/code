    if (ModelState.IsValid)
            {
                int index = 0;
                foreach (var files in galleryFilesAdd)
                {
                    var fileName = Guid.NewGuid().ToString("N");
                    var extension = Path.GetExtension(files.FileName).ToLower();
                    string thumbpath, imagepath = "";
                    using (var img = Image.FromStream(files.InputStream))
                    {
                     if(index < viewModel.imagecaption.Length){
                        var galleryImg = new hotel_gallery_image
                        {
                            hotel_id = hotel.id,
                            thumbPath = String.Format("/Resources/Images/Hotel/GalleryThumb/{0}{1}", fileName, extension),
                            imagePath = String.Format("/Resources/Images/Hotel/Gallery/{0}{1}", fileName, extension),
                            entry_datetime = DateTime.Now,
                            guid = Guid.NewGuid().ToString("N"),
                            enabled = true,
                            image_caption = viewModel.imagecaption[index]
                        };
                        db.hotel_gallery_image.Add(galleryImg);
                        index++;
                       }
                }
              }
