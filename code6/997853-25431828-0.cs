    byte[] binaryData;
    try {
          binaryData = 
             System.Convert.FromBase64String(base64String);
    }
    catch (System.ArgumentNullException) {
          //handling error
    }
    string myString = Encoding.Unicode.GetString(binaryData);
