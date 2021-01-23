    using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
     {
         DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)) 
         writer.WriteBytes(<<here your byte[] array>>);
         await writer.StoreAsync();
           
         var image = new BitmapImage();
         await image.SetSourceAsync(stream);
     }
