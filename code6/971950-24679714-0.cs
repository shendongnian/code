        public string HtmlString;
        public SlidePanel(Func<string> begin, Func<string> content, Func<string> end)
        {
            this.HtmlString = string.Format("{0}{1}{2}", begin(), content(), end());
        }
