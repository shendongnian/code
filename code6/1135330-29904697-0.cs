        public class TypeMatchManager
        {
            private Dictionary<Type, List<Type>> savedMatches = new Dictionary<Type, List<Type>>();
            public TypeMatchManager() { }
            public void AddMatch(Type firstType, Type secondType)
            {
                this.addToList(this.findListForType(firstType), secondType);
                this.addToList(this.findListForType(secondType), firstType);
            }
            public void DeleteMatch(Type firstType, Type secondType)
            {
                this.deleteFromList(this.findListForType(firstType), secondType);
                this.deleteFromList(this.findListForType(secondType), firstType);
            }
            public bool CanMatch(Type firstType, Type secondType)
            {
                List<Type> firstTypeList = this.findListForType(firstType);
                List<Type> secondTypeList = this.findListForType(secondType);
                return (firstTypeList.Contains(secondType) || secondTypeList.Contains(firstType));
            }
            private void addToList(List<Type> matchingTypes, Type matchingType)
            {
                if (!matchingTypes.Contains(matchingType))
                {
                    matchingTypes.Add(matchingType);
                }
            }
            private void deleteFromList(List<Type> matchingTypes, Type matchingType)
            {
                if (matchingTypes.Contains(matchingType))
                {
                    matchingTypes.Remove(matchingType);
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
 
