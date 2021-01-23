            /// <summary>
            /// Taking photo from the gallery
            /// </summary>
            private void SharePhotoClick(object sender, RoutedEventArgs e)
            {
                PhotoChooserTask ph=new PhotoChooserTask();
                ph.Completed += ph_Completed;
                ph.Show();
    
            }
    
            /// <summary>
            /// Sharing the photo to social media including email
            /// </summary>
            void ph_Completed(object sender, PhotoResult e)
            {
    
                ShareMediaTask smt = new ShareMediaTask();
                smt.FilePath = e.OriginalFileName;
                smt.Show();
            }
