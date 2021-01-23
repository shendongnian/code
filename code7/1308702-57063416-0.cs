    class CustomPageObjectMemberDecorator : DefaultPageObjectMemberDecorator, IPageObjectMemberDecorator
    {
        private BaseDriver driver;
        public CustomPageObjectMemberDecorator(BaseDriver driver) => this.driver = driver;
        public new object Decorate(MemberInfo member, IElementLocator locator)
        {
            FieldInfo field = member as FieldInfo;
            PropertyInfo property = member as PropertyInfo;
            Type targetType = null;
            if (field != null)
            {
                targetType = field.FieldType;
            }
            bool hasPropertySet = false;
            if (property != null)
            {
                hasPropertySet = property.CanWrite;
                targetType = property.PropertyType;
            }
            var genericType = targetType.GetGenericArguments().FirstOrDefault();
            if (field == null & (property == null || !hasPropertySet))
            {
                return null;
            }
            // IList<IWebElement>
            if (targetType == typeof(IList<IWebElement>))
            {
                return base.Decorate(member, locator);
            }
            // IWebElement
            else if (targetType == typeof(IWebElement))
            {
                return base.Decorate(member, locator);
            }
            // BaseElement and childs
            else if (typeof(BaseElement).IsAssignableFrom(targetType))
            {
                var bys = CreateLocatorList(member);
                var cache = ShouldCacheLookup(member);
                IWebElement webElement = (IWebElement)WebElementProxy.CreateProxy(locator, bys, cache);
                return GetElement(targetType, webElement, driver, field.Name);
            }
            // IList<BaseElement> and childs
            else if (targetType.GetInterfaces().FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>)) != null)
            {
                Type elementOfListTargetType = targetType.GetGenericArguments()[0];
                if (typeof(BaseElement).IsAssignableFrom(elementOfListTargetType))
                {
                    var cache = ShouldCacheLookup(member);
                    IList<By> bys = CreateLocatorList(member);
                    if (bys.Count > 0)
                    {
                        return CustomElementListProxy.CreateProxy(driver, field.Name, elementOfListTargetType, locator, bys, cache);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private Element GetElement(Type type, IWebElement webElement, BaseDriver baseDriver, string Name)
        {
            return (Element)type
                .GetConstructor(new[] { typeof(IWebElement), typeof(BaseDriver), typeof(string) })
                .Invoke(new object[] { webElement, baseDriver, Name });
        }
    }
    
