    public class Derived : Base
    {
        public Derived(Base b)  
        {
            SetProperties(b);
        }
    
        private void SetProperties(object mainClassInstance)
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var mainClassType = mainClassInstance.GetType();
            MemberInfo[] members = mainClassType.GetFields(bindingFlags).Cast<MemberInfo>()
                .Concat(mainClassType.GetProperties(bindingFlags)).ToArray();
            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType == MemberTypes.Property)
                {
                    var propertyInfo = memberInfo as PropertyInfo;
                    object value = propertyInfo.GetValue(mainClassInstance, null);
                    if (null != value)
                        propertyInfo.SetValue(this, value, null);
                }
                else
                {
                    var fieldInfo = memberInfo as FieldInfo;
                    object value = fieldInfo.GetValue(mainClassInstance);
                    if (null != value)
                        fieldInfo.SetValue(this, value);
                }
            }
        }
    }
