        private static void DoStuff()
        {
            var items = _baseList.OfType<DerivedClass>().ToList();
            foreach (var derivedItem in items)
            {
                derivedItem.BaseString += "Change...";
                RemoveItem(derivedItem);
            }
        }
        private static void RemoveItem(BaseClass derivedItem)
        {
            if (_baseList.Contains(derivedItem))
            {
                _baseList = _baseList.Remove(derivedItem);
            }
        }
