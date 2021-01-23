         private IList FilterList(IList list, string propName, Predicate<object> filterMethod) {
            var result = new List<object>();
            foreach (var item in list) {
                var value = item.GetType().GetProperty(propName).GetValue(item);
                if (filterMethod(value)) {
                    result.Add(item);
                }
            }
            return result;
            
        }
