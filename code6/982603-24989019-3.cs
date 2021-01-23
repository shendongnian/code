    class CustomResolver : DefaultContractResolver
    {
        protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
        {
            var contract = base.CreateDictionaryContract(objectType);
            var keyType = contract.DictionaryKeyType;
            if (keyType.BaseType == typeof(Enum))
            {
                contract.PropertyNameResolver = 
                         propName => ((int)Enum.Parse(keyType, propName)).ToString();
            }
            return contract;
        }
    }
