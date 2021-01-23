        public Isbn(int groupCode, int publisherCode, int titleCode, int checkCode)
        {
            _groupCode = groupCode;
            _publisherCode = publisherCode;
            _titleCode = titleCode;
            _checkCode = checkCode;
        }
        public static Isbn FromString(string isbn)
        {
            if (isbn == null)
                throw new ArgumentNullException("isbn");
            if (isbn == "") return;
            if (!IsValid(isbn)) return;
            var isbnStrings = isbn.Split(new[] {'-', ' '}, StringSplitOptions.RemoveEmptyEntries);
            var groupCode = Convert.ToInt32(isbnStrings[0]);
            var publisherCode = Convert.ToInt32(isbnStrings[1]);
            var titleCode = Convert.ToInt32(isbnStrings[2]);
            var checkCode = Convert.ToInt32(isbnStrings[3]);
            return new Isbn(groupCode, publisherCode, titleCode, checkCode);
        }
