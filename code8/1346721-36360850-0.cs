    public static string GetValue(this XElement element, string key){
           return values.Descendants("key")
                        .First(v => v.Value == key)
                        .ElementsAfterSelf("value")
                        .First()
                        .Value;
        }
