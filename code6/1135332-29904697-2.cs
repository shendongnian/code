        public class TypeMatchManager
        {
            private Dictionary<Type, List<Type>> savedMatches = new Dictionary<Type, List<Type>>();
            public TypeMatchManager() { }
            public void AddMatch(Type firstType, Type secondType)
            {
                this.addToList(firstType, secondType);
                this.addToList(secondType, firstType);
            }
            public void DeleteMatch(Type firstType, Type secondType)
            {
                this.deleteFromList(firstType, secondType);
                this.deleteFromList(secondType, firstType);
            }
            public bool CanMatch(Type firstType, Type secondType)
            {
                List<Type> firstTypeList = this.findListForType(firstType);
                List<Type> secondTypeList = this.findListForType(secondType);
                return (firstTypeList.Contains(secondType) || secondTypeList.Contains(firstType));
            }
            private void addToList(Type firstType, Type secondType)
            {
                var matchingTypes = this.findListForType(firstType);
                if (!matchingTypes.Contains(secondType))
                {
                    matchingTypes.Add(secondType);
                }
            }
            private void deleteFromList(Type firstType, Type secondType)
            {
                var matchingTypes = this.findListForType(firstType);
                if (matchingTypes.Contains(secondType))
                {
                    matchingTypes.Remove(secondType);
                }
            }
            private List<Type> findListForType(Type type)
            {
                foreach (var keyValuePair in savedMatches)
                {
                    if (keyValuePair.Key == type)
                    {
                        return keyValuePair.Value;
                    }
                }
                savedMatches.Add(type, new List<Type>());
                return findListForType(type);
            }
        }
 
