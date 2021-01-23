    System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
    ...
    System.Net.Http.HttpResponseMessage imageResponse = await client.GetAsync(imageUrl);
    // A memory stream where write the image data
    Windows.Storage.Streams.InMemoryRandomAccessStream randomAccess =
	new Windows.Storage.Streams.InMemoryRandomAccessStream();
    Windows.Storage.Streams.DataWriter writer = 
	new Windows.Storage.Streams.DataWriter(randomAccess.GetOutputStreamAt(0));
    // Write and save the data into the stream
    writer.WriteBytes(await imageResponse.Content.ReadAsByteArrayAsync());
    await writer.StoreAsync();
    // Create a Bitmap and assign it to the target Image control
    Windows.UI.Xaml.Media.Imaging.BitmapImage bm =
	new Windows.UI.Xaml.Media.Imaging.BitmapImage();
    await bm.SetSourceAsync(randomAccess);
    productimage.Source = bm;
