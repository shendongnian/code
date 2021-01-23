           //------------------- MTOM related stuff. Begin. ---------------------
            const string ATTCHMNT_PROP = "attachment_file_content";
            const string ATTCHMNT_CONTENT_ID = "Here goes content id";
            private string _ContentType;
            private string _MediaType;
            protected MimeContent _MyContent;
            protected MimePart _SoapMimeContent;
            protected MimePart _AttachmentMimeContent;
            protected GZipMessageEncoderFactory _Factory;
            protected MimeParser _MimeParser;
            private void SetupMTOM(GZipMessageEncoderFactory factory)
            {
                //
                _ContentType = "multipart/related";
                _MediaType = _ContentType;
                //
                // Create owned objects
                //
                _Factory = factory;
                _MimeParser = new MimeParser();
                //
                // Create object for the mime content message
                // 
                _SoapMimeContent = new MimePart()
                {
                    ContentTypeStart = "application/xop+xml",
                    ContentType = "text/xml",
                    ContentId = "Here goes envelope id",   // TODO: make content id dynamic or configurable?
                    CharSet = "UTF-8",                                  // TODO: make charset configurable?
                    TransferEncoding = "8bit"                         // TODO: make transfer-encoding configurable?
                };
                _AttachmentMimeContent = new MimePart()
                {
                    ContentType = "application/xml",                    // TODO: AttachmentMimeContent.ContentType configurable?
                    ContentId = ATTCHMNT_CONTENT_ID,                    // TODO: AttachmentMimeContent.ContentId configurable/dynamic?
                    TransferEncoding = "7bit"                         // TODO: AttachmentMimeContent.TransferEncoding dynamic/configurable?
                };
                _MyContent = new MimeContent()
                {
                    Boundary = "here goes boundary id"  // TODO: MimeContent.Boundary configurable/dynamic?
               };
                _MyContent.Parts.Add(_SoapMimeContent);
                _MyContent.Parts.Add(_AttachmentMimeContent);
                _MyContent.SetAsStartPart(_SoapMimeContent);
            }
            //------------------- MTOM related stuff. End. ----------------------
