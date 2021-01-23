    public static class CommentsExtractor
    {
        private static Regex preambleExpression =
            new Regex(@"^.*\[\d{2}-\w{3}-\d{4}.*(AM|PM)\]:\s");
        public static List<string> CommentsFromText(string text)
        {
            var comments = new List<string>();
            var lines = text.Split(new char[]{'\n', '\r'},
                StringSplitOptions.RemoveEmptyEntries);
            var currentComment = new StringBuilder();
            bool anyMatches = false;
            foreach (var line in lines)
            {
                var match = preambleExpression.Match(line);
                // If we see a new preamble, it's time to push
                //  the current comment into the list.
                // However, the first time through, we don't have
                //  any data, so we'll skip it.
                if(match.Success)
                {
                    if (anyMatches)
                    {
                        comments.Add(currentComment.ToString());
                        currentComment.Clear();
                    }
                    anyMatches = true;
                }
                currentComment.AppendLine(line);
            }
            // Now we need to push the last comment
            comments.Add(currentComment.ToString());
            return comments;
        }
    }
