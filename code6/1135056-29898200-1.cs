    XDocument xDoc = XDocument.Load(docDifPath);
    var infoRegions = from x in xDoc.Descendants("_Region")
                        select new
                        {
                            Name = x.Descendants("_Name").First().Value,
                            X1 = x.Descendants("_X1").First().Value,
                            Y1 = x.Descendants("_Y1").First().Value,
                            X2 = x.Descendants("_X2").First().Value,
                            Y2 = x.Descendants("_Y2").First().Value,
                            BlockTypeEnum = x.Descendants("_BlockTypeEnum").First().Value
                        };
    //using obtaining info. I created Region class before
    List<Region> regions = new List<Region>();
    foreach (var i in infoRegions)
    {
        Region region = new Region();
        region.name = i.Name;
        region.x1 = Convert.ToInt32(i.X1);
        region.y1 = Convert.ToInt32(i.Y1);
        region.x2 = Convert.ToInt32(i.X2);
        region.y2 = Convert.ToInt32(i.Y2);
        region.blockTypeEnumElem = (BlockTypeEnum)Enum.Parse(typeof(BlockTypeEnum), i.BlockTypeEnum);
        regions.Add(region);
    }
