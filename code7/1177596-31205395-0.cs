    var signed = message.Body as MultipartSigned;
    if (signed != null) {
        using (var ctx = new TemporaryMimeContext ()) {
            foreach (var signature in signed.Verify (ctx)) {
                try {
                    bool valid = signature.Verify ();
                    // If valid is true, then it signifies that the signed
                    // content has not been modified since this particular
                    // signer signed the content.
                    //
                    // However, if it is false, then it indicates that the
                    // signed content has
                    // been modified.
                } catch (DigitalSignatureVerifyException) {
                    // There was an error verifying the signature.
                }
            }
        }
    }
