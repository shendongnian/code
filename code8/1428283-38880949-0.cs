    public static void CopyListProperties<T>(this List<object> sourceList, List<T> destinationList) where T: new()
            {
                foreach (var item in sourceList)
                {
                    var destinationObject = new T();
                    item.CopyProperties(destinationObject);
                    destinationList.Add(destinationObject);
                }
            }
