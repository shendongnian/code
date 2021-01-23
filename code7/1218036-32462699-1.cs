    else if (decrypted is ApplicationPkcs7Mime) {
        var signed = (ApplicationPkcs7Mime) decrypted;
        if (signed.SecureMimeType == SecureMimeType.SignedData) {
            // extract the original content and get a list of signatures
            MimeEntity original;
    
            // Note: if you are rendering the message, you'll want to render the
            // original mime part rather than the application/pkcs7-mime part.
            foreach (var signature in pkcs7.Verify (out original)) {
                try {
                    bool valid = signature.Verify ();
    
                    // If valid is true, then it signifies that the signed content
                    // has not been modified since this particular signer signed the
                    // content.
                    // 
                    // However, if it is false, then it indicates that the signed
                    // content has been modified.
                } catch (DigitalSignatureVerifyException) {
                    // There was an error verifying the signature.
                }
            }
        }
    }
