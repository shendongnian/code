        Image img = new Image()
        {
            Path = fi.DirectoryName
        };
        this._dc.Images.Add(img);
        foreach (var tag in tags)
        {
            Tag tag = new Tag()
            {
                Phrase = tag
            };
            this._dc.Tags.Add();
            ImageTagId = new ImageTagId { Image = image, Tag = tag };
            this._dc.ImageTagIds.Add(ImageTagId);
        }
