        public async void OnTakePhotoButtonClicked(object sender, EventArgs args)
        {
            var file = await cameraOps.SelectPicture();
            someImage.ImageSource = ImageSource.FromStream(() => file.Source);
        }
