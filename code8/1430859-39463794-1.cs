    // Assuming you have your JSON string already
    string json = "{\"key\":\"secret_value\"}";
    
    // Get the "pk" request parameter from the http request however you need to
    string base64PublicKey = request.getParameter("pk");
    string publicXmlKey = Encoding.ASCII.GetString(Convert.FromBase64String(base64PublicKey));
    // TODO: If you want the extra validation, insert "publicXmlKey" into the json value before 
    //       converting it to bytes
    // var jo = parse(json); jo.pk = publicXmlKey; json = jo.ToString();
    // Convert the string to bytes
    byte[] jsonBytes = Encoding.ASCII.GetBytes(json);
    
    // Encrypt the json using the public key provided by the client
    RSACryptoServiceProvider rsaEncrypt = new RSACryptoServiceProvider();
    rsaEncrypt.FromXmlString(publicXmlKey);
    byte[] encryptedJsonBytes = rsaEncrypt.Encrypt(jsonBytes, false);
    
    // Send the encrypted json back to the client
    return encryptedJsonBytes;
