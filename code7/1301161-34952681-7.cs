    public class ItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static readonly Type EnumType = GenerateEnumType();
        private object _value;
        public object Value
        {
            get { return _value; }
            set
            {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelValue)));
            }
        }
        public string SelValue
        {
            get
            {
                return String.Join(",", 
                    Enum.GetValues(EnumType).OfType<object>().Where(v => ((int)_value & (int)v) != 0).Select(v => v.ToString()));
            }
            set
            {
                var strings = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());        
                _value = Enum.ToObject(EnumType, strings.Aggregate(0, (acc, val) => acc | (int)Enum.Parse(EnumType, val)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelValue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }
        public ObservableCollection<string> Items
        {
            get
            {
                return new ObservableCollection<string>(Enum.GetNames(EnumType));
            }
        }
        public static Type GenerateEnumType()
        {
            string asmNameString = "flags_enum";
            
            //    Create Base Assembly Objects
            AppDomain appDomain = AppDomain.CurrentDomain;
            AssemblyName asmName = new AssemblyName(asmNameString);
            AssemblyBuilder asmBuilder = appDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Run);
            //    Create Module and Enumeration Builder Objects
            ModuleBuilder modBuilder = asmBuilder.DefineDynamicModule(asmNameString + "_module");
            EnumBuilder enumBuilder = modBuilder.DefineEnum(asmNameString, TypeAttributes.Public, typeof(int));
            Type fa = typeof(FlagsAttribute);
            
            CustomAttributeBuilder attributeBuilder =
                     new CustomAttributeBuilder(fa.GetConstructor(new Type[0]), new object[0]);
            enumBuilder.SetCustomAttribute(attributeBuilder);
            for (int i = 0; i < 7; i++)
            {
                enumBuilder.DefineLiteral($"Test{i + 1}", 1 << i);
            }
            return enumBuilder.CreateType();
        }
    }
