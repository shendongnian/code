        public string EndorseImageLink
        {
            set
            {
                EndorseImagesLink.Clear();
                foreach (var endorseImageUrl in value.Split(',').Where(endorseImageUrl => !string.IsNullOrEmpty(endorseImageUrl)))
                {
                    EndorseImagesLink.Add(endorseImageUrl);
                }
            }
        }
        public List<string> EndorseImagesLink
        {
            get { return _endorseImagesLink ?? (_endorseImagesLink = new List<string>()); }
            private set { _endorseImagesLink = value; }
        }
