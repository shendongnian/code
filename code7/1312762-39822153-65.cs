    var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjbGFpbTEiOjAsImNsYWltMiI6ImNsYWltMi12YWx1ZSJ9.8pwBI_HtXqI3UgQHQ_rDRnSQRxFL1SR8fbQoS-5kM5s";
    var secretKey = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
    try
    {
        string jsonPayload = JWT.JsonWebToken.Decode(token, secretKey);
        Console.WriteLine(jsonPayload);
    }
    catch (JWT.SignatureVerificationException)
    {
        Console.WriteLine("Invalid token!");
    }
