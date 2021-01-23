    var rootObject = new RootObject
    {
        items = new List<Item>
        {
            new Item
            {
                etag = "123etag"
            }
        }
    };
    rootObject.items.FirstOrDefault().etag;
