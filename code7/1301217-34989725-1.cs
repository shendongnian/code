    [TestMethod]
    public void VerifyEncoding_CorrectCharsGiven()
    {
        var value = "hello my friends";
        var encoding = Encoding.GetEncoding("iso-8859-1", EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
        var bytes = encoding.GetBytes(value); // no exception
    }
