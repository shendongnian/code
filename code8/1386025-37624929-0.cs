    /// <summary>
    /// Visits a MimeMessage and splits attachments into those that are
    /// referenced by the HTML body vs regular attachments.
    /// </summary>
    class AttachmentVisitor : MimeVisitor
    {
        List<MultipartRelated> stack = new List<MultipartRelated> ();
        List<MimeEntity> attachments = new List<MimeEntity> ();
        List<MimePart> embedded = new List<MimePart> ();
        bool foundBody;
    
        /// <summary>
        /// Creates a new AttachmentVisitor.
        /// </summary>
        public AttachmentVisitor ()
        {
        }
    
        /// <summary>
        /// The list of attachments that were in the MimeMessage.
        /// </summary>
        public IList<MimeEntity> Attachments {
            get { return attachments; }
        }
        /// <summary>
        /// The list of embedded images that were in the MimeMessage.
        /// </summary>
        public IList<MimePart> EmbeddedImages {
            get { return embedded; }
        }
    
        protected override void VisitMultipartAlternative (MultipartAlternative alternative)
        {
            // walk the multipart/alternative children backwards from greatest level of faithfulness to the least faithful
            for (int i = alternative.Count - 1; i >= 0 && body == null; i--)
                alternative[i].Accept (this);
        }
    
        protected override void VisitMultipartRelated (MultipartRelated related)
        {
            var root = related.Root;
    
            // push this multipart/related onto our stack
            stack.Add (related);
    
            // visit the root document
            root.Accept (this);
    
            // pop this multipart/related off our stack
            stack.RemoveAt (stack.Count - 1);
        }
    
        // look up the image based on the img src url within our multipart/related stack
        bool TryGetImage (string url, out MimePart image)
        {
            UriKind kind;
            int index;
            Uri uri;
    
            if (Uri.IsWellFormedUriString (url, UriKind.Absolute))
                kind = UriKind.Absolute;
            else if (Uri.IsWellFormedUriString (url, UriKind.Relative))
                kind = UriKind.Relative;
            else
                kind = UriKind.RelativeOrAbsolute;
    
            try {
                uri = new Uri (url, kind);
            } catch {
                image = null;
                return false;
            }
    
            for (int i = stack.Count - 1; i >= 0; i--) {
                if ((index = stack[i].IndexOf (uri)) == -1)
                    continue;
    
                image = stack[i][index] as MimePart;
                return image != null;
            }
    
            image = null;
    
            return false;
        }
    
        // called when an HTML tag is encountered
        void HtmlTagCallback (HtmlTagContext ctx, HtmlWriter htmlWriter)
        {
            if (ctx.TagId == HtmlTagId.Image && !ctx.IsEndTag && stack.Count > 0) {
                // search for the src= attribute
                foreach (var attribute in ctx.Attributes) {
                    if (attribute.Id == HtmlAttributeId.Src) {
                        MimePart image;
    
                        if (!TryGetImage (attribute.Value, out image))
                            continue;
    
                        if (!embedded.Contains (image))
                            embedded.Add (image);
                    }
                }
            }
        }
    
        protected override void VisitTextPart (TextPart entity)
        {
            TextConverter converter;
    
            if (foundBody) {
                // since we've already found the body, treat this as an
                // attachment
                attachments.Add (entity);
                return;
            }
    
            if (entity.IsHtml) {
                converter = new HtmlToHtml {
                    HtmlTagCallback = HtmlTagCallback
                };
    
                converter.Convert (entity.Text);
            }
    
            foundBody = true;
        }
    
        protected override void VisitTnefPart (TnefPart entity)
        {
            // extract any attachments in the MS-TNEF part
            attachments.AddRange (entity.ExtractAttachments ());
        }
    
        protected override void VisitMessagePart (MessagePart entity)
        {
            // treat message/rfc822 parts as attachments
            attachments.Add (entity);
        }
    
        protected override void VisitMimePart (MimePart entity)
        {
            // realistically, if we've gotten this far, then we can treat
            // this as an attachment even if the IsAttachment property is
            // false.
            attachments.Add (entity);
        }
    }
