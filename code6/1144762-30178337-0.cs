    if (successNode != null)
    {
        var _data = xDoc.Descendants("data").FirstOrDefault();
        var _count = int.Parse(_data.Attribute("count").Value);
        if(_count > 0)
        {
            var listType = _data.Attribute("listtype").Value;
            _objectCollection = new QueryObjectCollection(listType);
            foreach (var item in _data.Elements(listType))
            {
                var recordNo = item.Element("RECORDNO");
                if (recordNo != null)
                {
                    _objectCollection.Keys.Add(recordNo.Value);
                    _objectCollection.Objects.Add(item);
                }
            }
        }
    }
