        public void SetValueIfContains(string source, string search, string value, MyClass item)
        {
            if (source.Contains(search))
            {
                item.InsurerNameShort = value;
            }
        }
        public void YourFunction()
        {
            var loweredQuoteItem = quovteItem.Name.ToLower();
            SetValueIfContains(loweredQuoteItem, "one", "Item One", Item);
            SetValueIfContains(loweredQuoteItem, "two", "Item Two", Item);
            SetValueIfContains(loweredQuoteItem, "Chaucer", "Item chaucer", Item);
        }
