    foreach (var file in files)
    {
       if (file.Length > 0)
        {
          var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
          using (var reader = new StreamReader(file.OpenReadStream()))
          {
            string contentAsString = reader.ReadToEnd();
            byte[] bytes = new byte[contentAsString.Length * sizeof(char)];
            System.Buffer.BlockCopy(contentAsString.ToCharArray(), 0, bytes, 0, bytes.Length);
          }
       }
    }
