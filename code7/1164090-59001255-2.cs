    private class DictionaryResult<K, V>
        {
            public K Key { get; set; }
            public V Value { get; set; }
        }
2. define your SQL:
private const string SQL = "select Acct_No as Key, XX as Value from XXXXX where acct_no in ( :accts)";
3. use the generic class to return a list of keyvalueapair:
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
