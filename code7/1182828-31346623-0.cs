     Dictionary<string, object> ConvertToDictionary(System.Collections.IDictionary iDic) {
    			var dic = new Dictionary<string, object>();
    			var enumerator = iDic.GetEnumerator();
    			while (enumerator.MoveNext()) {
    				dic[enumerator.Key.ToString()] = enumerator.Value;
    			}
    		return dic;
        }
