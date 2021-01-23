    [TestMethod]
    public void VerifyEncoding_UTF8CharsGiven()
    {
        var value = "hello ☃❆⛇✺⑳⑯✵ȳה";
        var encoding = Encoding.GetEncoding("iso-8859-1", EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
        try
        {
            var bytes = encoding.GetBytes(value);
            Assert.Fail("EncoderFallbackException should have occured");
        }
        catch (EncoderFallbackException ex)
        {
            // Unable to translate Unicode character \u1F384 at index 6 to specified code page.
            Debug.WriteLine(ex.Message);
        }
    }
