           public GZipMessageEncoderFactory(MessageEncoderFactory messageEncoderFactory)
        {
            if (messageEncoderFactory == null)
                throw new ArgumentNullException("messageEncoderFactory", "A valid message encoder factory must be passed to the GZipEncoder");
            encoder = new GZipMessageEncoder(messageEncoderFactory.Encoder, this);
        }
