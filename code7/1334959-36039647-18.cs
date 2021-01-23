           //------------------- MTOM related stuff. Begin. ---------------------
            const string ATTCHMNT_PROP = "aca_file_content";
            const string ATTCHMNT_CONTENT_ID = "<UZE_26123_>";
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
                    ContentId = "<http://tempuri.org/0/EFD659EE6BD5F31EA7BC0D59403AF049>",   // TODO: make content id dynamic or configurable?
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
                    //Boundary = "------=_Part_0_21714745.1249640163820"  // TODO: MimeContent.Boundary configurable/dynamic?
                    Boundary = "id_Part_0_21714745.1249640163820"  // TODO: MimeContent.Boundary configurable/dynamic?
               };
                _MyContent.Parts.Add(_SoapMimeContent);
                _MyContent.Parts.Add(_AttachmentMimeContent);
                _MyContent.SetAsStartPart(_SoapMimeContent);
            }
            //------------------- MTOM related stuff. End. ----------------------
