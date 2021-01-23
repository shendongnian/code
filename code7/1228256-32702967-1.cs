        public static IEnumerable<string> GetImagePaths()
        {
            var db = new MyDataClassDataContext();
            var value = (from im in db.Images select im.Path).ToList();
            db.Dispose();
            return value;
        }
