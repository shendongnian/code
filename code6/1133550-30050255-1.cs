    private void button1_Click(object sender, EventArgs e)
    {
        var service = new PicasaService("exampleCo-exampleApp-1");
        service.setUserCredentials("me.myself@gmail.com", "-secret-");
        AlbumQuery query = new AlbumQuery(PicasaQuery.CreatePicasaUri("default"));
    
    
        PicasaFeed feed = service.Query(query);
        var entry = (PicasaEntry)feed.Entries.SingleOrDefault(f => f.Title.Text == "Testalbum");
    
        var ac = new AlbumAccessor(entry);
    
        var photoQuery = new PhotoQuery(PicasaQuery.CreatePicasaUri("default", ac.Id));
        PicasaFeed photoFeed = service.Query(photoQuery);
    
        DirectoryInfo srcdir = Directory.CreateDirectory("C:\\Temp\\Testalbum");
        DownloadAllPhotos("C:\\Temp\\Testalbum", photoFeed.Entries);
    
        foreach (PicasaEntry oldentry in photoFeed.Entries)
        {
            oldentry.Delete();
        }
    
        DirectoryInfo tgtdir = Directory.CreateDirectory("C:\\Temp\\Converted");
        foreach (FileInfo imagefile in srcdir.EnumerateFiles())
        {
            Image img = Image.FromFile(imagefile.FullName);
    
            PropertyItem PiDtOrig = null;
            try
            {
                PiDtOrig = img.GetPropertyItem(0x9003); // id 0x9003 is "DateTimeOriginal"
            }
            catch (System.ArgumentException ex) // this exception is thrown when PropertyItem does not exist 
            {
                PiDtOrig = NewPropertyItem();
                PiDtOrig.Id = 0x9003;
                PiDtOrig.Type = 7;
                PiDtOrig.Len = 4;
            }
    
            PiDtOrig.Value = BitConverter.GetBytes(DateTimeToInt(DateTime.Now));
            img.SetPropertyItem(PiDtOrig);
            string ConvImgName = tgtdir.FullName + "\\" + imagefile.Name;
            img.Save(ConvImgName);
    
            //ExifTagCollection exif = new ExifTagCollection(img);
            //Debug.WriteLine(exif);
    
            Uri postUri = new Uri(PicasaQuery.CreatePicasaUri("hommel.peter@gmail.com", ac.Id));
            FileStream fileStream = imagefile.OpenRead();
    
            PicasaEntry newentry = (PicasaEntry)service.Insert(postUri, fileStream, "image/jpeg", ConvImgName);
    
            fileStream.Close();
            fileStream.Dispose();
        }
    }
    
    private PropertyItem NewPropertyItem()
    {
        Type t = typeof (PropertyItem);
        ConstructorInfo ctor = t.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0];
        Object o = ctor.Invoke(new Object[] { });
        return (PropertyItem) o;
    }
    
    private int DateTimeToInt(DateTime theDate)
    {
        return (int)(theDate.Date - new DateTime(1900, 1, 1)).TotalDays + 2;
    }
    
    // taken from https://codethis.wordpress.com/2008/11/ and modified for this example
    static void DownloadAllPhotos(string DirectoryName, AtomEntryCollection photoList)
    {
        DirectoryInfo dirInfo = Directory.CreateDirectory(DirectoryName);
    
        int photoNum = 1;
        foreach (AtomEntry photo in photoList)
        {
            HttpWebRequest photoRequest = WebRequest.Create(photo.Content.AbsoluteUri) as HttpWebRequest;
            HttpWebResponse photoResponse = photoRequest.GetResponse() as
               HttpWebResponse;
    
            BufferedStream bufferedStream = new BufferedStream(
               photoResponse.GetResponseStream(), 1024);
            BinaryReader reader = new BinaryReader(bufferedStream);
    
            FileStream imgOut = File.Create(dirInfo.FullName + "\\image" +
               photoNum++ + ".jpg");
            BinaryWriter writer = new BinaryWriter(imgOut);
    
            int bytesRead = 1;
            byte[] buffer = new byte[1024];
            while (bytesRead > 0)
            {
                bytesRead = reader.Read(buffer, 0, buffer.Length);
                writer.Write(buffer, 0, bytesRead);
            }
            reader.Close();
            reader.Dispose();
            writer.Flush();
            writer.Close();
            writer.Dispose();
        }
    }
