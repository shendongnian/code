    private List<string> _endorseImagesLink = new List<string> ();
    public List<string> EndorseImagesLink
            {
                get { return _endorseImagesLink ; }
                set
                {
                    _endorseImagesLink.Clear();
                    foreach (var endorseImageUrl in this.EndorseImageLink.Split(','))
                    {
                        if (endorseImageUrl.IsNotNullOrEmpty())
                        {
                            _endorseImagesLink .Add(endorseImageUrl);
                        }
                    }
                }
            }
