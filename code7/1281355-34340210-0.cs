        [IgnoreDataMember]
        public IEnumerable<string> CommentsFromDb
        {
            set
            {
                Comments = string.Join(", ", value);
            }
        }
