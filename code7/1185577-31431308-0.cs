     private void DetachRasterImage(Transaction transaction, Database database, List<string> jpgPaths)
        {
            Dictionary<ObjectId, RasterImageDef> imageDefinitions = new Dictionary<ObjectId, RasterImageDef>();
            DBDictionary imageDictionary = (DBDictionary)transaction.GetObject(RasterImageDef.GetImageDictionary(database), OpenMode.ForWrite);
            foreach (DBDictionaryEntry entry in imageDictionary)
            {
                ObjectId id = (ObjectId)entry.Value;
                RasterImageDef rasterImageDef = transaction.GetObject(id, OpenMode.ForWrite) as RasterImageDef;
                if (jpgPaths.Contains(rasterImageDef.LocateActivePath()))
                    imageDefinitions.Add(id, rasterImageDef);
            }
            foreach (KeyValuePair<ObjectId, RasterImageDef> item in imageDefinitions)
            {
                imageDictionary.Remove(item.Key);
                item.Value.Erase();
            }           
        }
