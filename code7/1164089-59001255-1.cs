    public List<KeyValuePair<int, string>> GetXXX(string accts)
        {
            using (var securityEntities = ODPFactory.GetSecurityEntities(_ownerRef))
            {
                var returnValue = securityEntities.ExecuteStoreQuery<DictionaryResult<int, string>>(SQL, new object[] { accts })
                    .Select(item => new KeyValuePair<int, string>(item.Key, item.Value))
                    .ToList();
                return returnValue;
            }
        }
