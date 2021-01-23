        /// <summary>
        /// The content of the message as plain text (if available)
        /// </summary>
        [XmlIgnore]
        public IMAPMessageContent TextData
        {
            get 
            { 
                //RefreshData(true, false); 
                foreach (IMAPMessageContent content in _bodyParts)
                {
                    if (content.ContentType.ToLower().Contains("plain"))
                        return content;
                }
                return null;
            }
            //set { _textData = value; }
        }
