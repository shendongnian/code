    [...]
    string base64String;
    var signatureMemoryStream = signature as MemoryStream;
    if (signatureMemoryStream == null)
    {
        signatureMemoryStream = new MemoryStream();
        signature.CopyTo( signatureMemoryStream );
    }
    var byteArray = signatureMemoryStream.ToArray();
    base64String = Convert.ToBase64String( byteArray );
