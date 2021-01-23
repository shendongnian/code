        public Item GetMediaItem(string localPath)
        {
            int indexA = -1;
            string strB = string.Empty;
            string str1 = MainUtil.DecodeName(localPath);
            foreach (string str2 in MediaManager.Provider.Config.MediaPrefixes.Select(MainUtil.DecodeName))
            {
                indexA = str1.IndexOf(str2, StringComparison.InvariantCultureIgnoreCase);
                if (indexA >= 0)
                {
                    strB = str2;
                    break;
                }
            }
            if (indexA < 0 || string.Compare(str1, indexA, strB, 0, strB.Length, true, CultureInfo.InvariantCulture) != 0)
                return null;
            string id = StringUtil.Divide(StringUtil.Mid(str1, indexA + strB.Length), '.', true)[0];
            if (id.EndsWith("/", StringComparison.InvariantCulture))
                return null;
            Database database = Sitecore.Context.Database;
            if (ShortID.IsShortID(id))
                return database.GetItem(ShortID.Decode(id));
            string path = "/sitecore/media library/" + id.TrimStart('/');
            var mediaItem = database.GetItem(path);
            if (mediaItem != null)
            {
                return mediaItem;
            }
            Item root = database.GetItem("/sitecore/media library");
            if (root != null)
            {
                Item item = new ItemPathResolver().ResolveItem(StringUtil.Divide(StringUtil.Mid(localPath, indexA + strB.Length), '.', true)[0], root);
                if (item != null)
                    return item;
            }
            return null;
        }
