    byte[] binaryData;
      binaryData = new Byte[product.BrochureFile.InputStream.Length];
      long bytesRead = product.BrochureFile.InputStream.Read(binaryData, 0, (int)product.BrochureFile.InputStream.Length);
      product.BrochureFile.InputStream.Close();
      string base64String = System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
