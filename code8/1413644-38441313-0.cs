    public async void Button_Click(object sender, RoutedEventArgs e) {
        ...
        var processedBitmap = await ProcessBitmap(bitmap);
        ...
    }
    public async Task<Bitmap> ProcessBitmap(Bitmap bitmap) {
        //on bitmap asynchronously
        await Task.Run(() => {
            return DoActualBitmapProcessing(bitmap);
        }
    } 
