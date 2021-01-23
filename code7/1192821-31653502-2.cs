    static void Main(string[] args)
    {         
        var serializationSettings = new JsonSerializerSettings
        {
            Error = HandleDeserializationError
        };
        var lst = JsonConvert.DeserializeObject<List<MyClass>>(jsonStr, serializationSettings);
        }
        public static void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            errorArgs.ErrorContext.Handled = true;
            var currentObj = errorArgs.CurrentObject as MyClass;
            
            if (currentObj == null) return;
            currentObj.MyEnumValue = MyEnum.Type2;            
        }
