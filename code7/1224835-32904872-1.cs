    var dictionaryByMonth = new Dictionary<DictKey, List<DictValue>>();
    dictionaryByMonth.Add(new DictKey("Set1"), new List<DictValue> { new DictValue(0), new DictValue(2), new DictValue(4), new DictValue(6), new DictValue(8) });
    dictionaryByMonth.Add(new DictKey("Set2"), new List<DictValue> { new DictValue(1), new DictValue(2), new DictValue(5), new DictValue(6), new DictValue(11) });
            
    var rowsByMonth = dictionaryByMonth.Select(item => GetExpando(item));
