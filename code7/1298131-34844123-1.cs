    public XDocument createData(string[,] banciforxml)
    {
        XDocument Bancile = new XDocument();
        XElement root = new XElement("banci");
        Bancile.Add(root);
        //Go through the first dimension of the array
        for (int i = banciforxml.GetLowerBound(0); i <= banciforxml.GetUpperBound(0); i++)
        {
            var d1element = new XElement("bancks");
            root.Add(d1element);
            //Go though the second dimension of the array
            for (int j = banciforxml.GetLowerBound(1); j <= banciforxml.GetUpperBound(1); j++)
            {
                var value = banciforxml[i, j];
                if(value == null)
                    continue;
                var d2element = new XElement("item" + (j+1));
                d2element.Value = value;
                d1element.Add(d2element);
            }
        }
        return Bancile;
    }
