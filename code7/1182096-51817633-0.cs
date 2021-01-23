            protected override JsonContract CreateContract(Type objectType)
            {
                if (typeof(T).IsAssignableFrom(objectType)
                    || Nullable.GetUnderlyingType(objectType) != null && typeof(T).IsAssignableFrom(Nullable.GetUnderlyingType(objectType)))
                {
                    var contract = this.CreateObjectContract(objectType);
                    contract.Converter = null; // Also null out the converter to prevent infinite recursion.
                    return contract;
                }
                return base.CreateContract(objectType);
            }
