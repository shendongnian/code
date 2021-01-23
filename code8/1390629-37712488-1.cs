    public class Program
    {
        public void Main()
        {
            Empl test = new Empl()
            {
                TestProp = "blub",
                TestInt = 1
            };
            if (test.ValidateProperties(Validations.CheckEmptyStringsAndZeroInts))
            {
                Console.WriteLine("validation passed");
            }
            else
            {
                Console.WriteLine("validation failed");
            }
        }
    }
    private static class Validations
    {
        //put this in a static class with standard checks
        public static Func<object, bool> CheckEmptyStringsAndZeroInts = o =>
        {
            if (o is string && string.IsNullOrEmpty((string)o))
            {
                    return false;
            }
            else if (o is int && ((int) o) == 0)
            {
                return false;
            }
            // ignore other property types
            return true;
        };
    }
    // Derive all your models like this. deriving from an Empl class is still valid and working!
    //[IncludeBindingFlagsForPropertyReflctionAttribute(/*your custom binding flags*/)] //can also override the binding flags in derived classes!
    public class Empl : DtoBase<Empl>
    {
        public string TestProp { get; set; }
        public int TestInt { get; set; }
        // Your properties here
    }
    // Helps you to control the targeted properties. you can filter for public or protected members for example
    public class IncludeBindingFlagsForPropertyReflctionAttribute : Attribute
    {
        public BindingFlags BindingFlags { get; }
        public IncludeBindingFlagsForPropertyReflctionAttribute(BindingFlags propertySearchBindingFlags)
        {
            BindingFlags = propertySearchBindingFlags;
        }
    }
    //Looks much. But used once as base class can do those validations for you
    [IncludeBindingFlagsForPropertyReflction(BindingFlags.Public | BindingFlags.Instance)]
    public abstract class DtoBase<TDto> where TDto : DtoBase<TDto>
    {
        private static Dictionary<Type, List<PropertyInfo>> DtoPropertyInfosStorage { get; }
        private List<PropertyInfo> DtoPropertyInfos => DtoPropertyInfosStorage[typeof (TDto)];
        static DtoBase()
        {
            DtoPropertyInfosStorage = new Dictionary<Type, List<PropertyInfo>>();
            Type tDto = typeof (TDto);
            var includeBindingFlagsForProperty = GetAttribute(tDto);
            BindingFlags defaultTargetFlags = BindingFlags.Instance | BindingFlags.Public;
            DtoPropertyInfosStorage.Add(typeof(TDto), new List<PropertyInfo>(typeof(TDto).GetProperties(includeBindingFlagsForProperty?.BindingFlags ?? defaultTargetFlags)));
        }
        private static IncludeBindingFlagsForPropertyReflctionAttribute GetAttribute(Type dtoType)
        {
            bool stopRecursion = !dtoType.IsSubclassOf(typeof(DtoBase<TDto>));
            var includeBindingFlagsForProperty = dtoType.GetCustomAttributes(typeof(IncludeBindingFlagsForPropertyReflctionAttribute)).FirstOrDefault();
            if (includeBindingFlagsForProperty == null && !stopRecursion)
            {
                return GetAttribute(dtoType.BaseType);
            }
            return null;
        }
        /// <summary>
        /// You can handle your validation type in you validation function yourself.
        /// </summary>
        public bool ValidateProperties(Func<object, bool> validationFunction)
        {
            foreach (KeyValuePair<Type, List<PropertyInfo>> dtoPropertyInfo in DtoPropertyInfosStorage)
            {
                foreach (PropertyInfo propertyInfo in DtoPropertyInfos)
                {
                    if (!validationFunction(propertyInfo.))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// You can pass your targeted property type like string to TPropertyType
        /// <![CDATA[ Example:
        /// if(ValidateProperties<string>(validate => !string.IsNullOrEmpty(validate)))
        /// {
        ///     properties not empty?
        /// }
        /// ]]]]>
        /// </summary>
        public bool ValidateProperties<TPropertyType>(Func<TPropertyType, bool> validationFunction)
        {
            List<PropertyInfo> targetPropertyInfos =
                DtoPropertyInfos.Where(prop => prop.PropertyType == typeof (TPropertyType))
                    .ToList();
            foreach (PropertyInfo dtoPropertyInfo in targetPropertyInfos)
            {
                if (validationFunction((TPropertyType) dtoPropertyInfo.GetValue(this)))
                {
                    return false;
                }
            }
            return true;
        }
    }
