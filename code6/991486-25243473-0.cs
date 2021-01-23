    foreach (XElement element in scan.Descendants("iconCode"))
    {
         string iconCode1 = element.Value;
         Int32 result;                             
         Int32.TryParse(iconCode1, out result);
         string iconFilename2 = "cond" + string.Format("{0:00#}", result) + ".png";
         xFore.Root.Add(new XElement("img_small", weatherImages + @"Small/" + iconFilename2),
         new XElement("img_large", weatherImages + @"Large/" + iconFilename2));
    }
