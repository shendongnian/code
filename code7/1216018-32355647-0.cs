        public Books(bool comments)
        {
            if (comments)
                CommentsList = new List<Comments>();
            else
                RatingList = new List<Rating>();
        }
