        public string NamespaceAndName
        {
            get
            {
                if (_namespace == SvgNamespace)
                    return _name;
                return GetFirst(Namespaces, _namespace).Key + ":" + _name;
            }
        }
        private KeyValuePair<string, string> GetFirst(List<KeyValuePair<string,string>> namespaces,string yourNamespaceToMatch)
        {
            for (int i = 0; i < namespaces.Count; i++)
            {
                if (namespaces[i].Value == yourNamespaceToMatch)
                    return namespaces[i];
            }
            throw new InvalidOperationException("Sequence contains no matching element");
        }
