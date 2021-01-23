    private async void BtnPost_Click(object sender, RoutedEventArgs e)
        {
            ParseFile ImageFile = new ParseFile(FileName, myPic);
            await ImageFile.SaveAsync();
            var imageUpload = new ParseObject("ImageUpload ");
            imageUpload["photo"] = ImageFile;
           
            await imageUpload.SaveAsync();
        }
