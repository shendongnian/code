    var bufferingStream = new BufferingStream();
    
    Task.Run(() =>
    {
        using(var inputStream = GetTheStreamFromSomewhere();
        using(var finalDestinationOutputStream = bufferingStream.GetWritingStream())
        using(var outputStream = new TransformingOutputStream(finalDestinationOutputStream))
        {
            inputStream.CopyTo(outputStream);
        }
    }
    
    using(var someInputStream = bufferingStream.GetReadingStream()) //Technically a using is not necessary on the reading stream but it is good to keep good habits.
    {
        MagicStreamReadingLibrary.ProcessStream(someInputStream);
    }
