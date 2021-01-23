    private static Item ItemFromFields(IEnumerable<XElement> fields)
    {
        var item = new Item();
    
        foreach (var field in fields)
        {
            var index = (int)field.Attribute("index");
    
            switch (index)
            {
                case 1:
                    item.Url = (string)field.Element("url");
                    break;
                case 2:
                    item.Question = field.Value;
                    break;
                case 3:
                    item.Answer = field.Value;
                    break;
                case 4:
                    item.Remark = field.Value;
                    break;
                case 5:
                    item.Reveal = field.Value;
                    break;
            }
        }
    
        return item;
    }
