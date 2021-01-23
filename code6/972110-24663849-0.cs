        private int index = 1;
        public void chooseImage_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult != TaskResult.OK || e.ChosenPhoto == null)
            {
                return;
            }
            Image img = new Image();
            WriteableBitmap SelectedBitmap = new WriteableBitmap(60, 60);
            img.Width = 100;
            img.Height = 100;
            img.Name = "img";
            SelectedBitmap.SetSource(e.ChosenPhoto);
            img.Source = SelectedBitmap;
            img.Name = "Photo " + index++; // Set unique name here 
            e.ChosenPhoto.Position = 0;
            CollageCanvas.Children.Add(img);
            Canvas.SetTop(img, 50);
            Canvas.SetLeft(img, 50);
        }
