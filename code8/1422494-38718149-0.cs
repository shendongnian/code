    public class AdminManager : IAdminService
    {
        public IEnumerable<SecurityGroup> SecurityGroups()
        {
            IEnumerable<SecurityGroup> list = null;
            XmlDocument xmlDoc = new XmlDocument();
            using (var c = new FMContext())
            {
                var xmlData = c.Database.SqlQuery<string>("AllSecurtyUsersProc").FirstOrDefault();
                if (xmlData != null)
                {
                    xmlDoc.LoadXml(xmlData);
                    list = ConvertXmlToClass<SecurityGroup>(xmlDoc, "/SecurityGroups/SecurityGroup");
                }
            }
            return list;
        }
        public static IEnumerable<T> ConvertXmlToClass<T>(XmlDocument doc, string nodeString)
            where T : class, new()
        {
            var xmlNodes = doc.SelectNodes(nodeString);
            List<T> list = new List<T>();
            foreach (XmlNode node in xmlNodes)
            {
                var item = GetNewItem<T>(node);
                list.Add(item);
            }
            return list;
        }
        
        public static T GetNewItem<T>(XmlNode node)
            where T : class, new()
        {
            var type = typeof(T);
            var item = new T();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                var propertyName = property.Name;
                object value = null;
                if (IsEnumerable(property))
                {
                    value = GetNodeCollectionValue(property, node);
                }
                else
                {
                    value = GetNodeValue(node, propertyName);
                }
                if (value != null)
                {
                    property.SetValue(item, Convert.ChangeType(value, propertyType), null);
                }
            }
            return item;
        }
        private static object GetNodeCollectionValue(PropertyInfo property, XmlNode node)
        {
            var doc = new XmlDocument();
            var itemType = property.PropertyType.GenericTypeArguments[0];
            var xml = node.InnerXml;
            if (xml.Contains(property.Name))
            {
                var start = xml.IndexOf($"<{property.Name}>");
                var length = xml.IndexOf($"</{property.Name}>") - start + ($"</{property.Name}>").Length;
                xml = xml.Substring(start, length);
                doc.LoadXml(xml);
                if (itemType != null)
                {
                    var type = typeof(AdminManager);
                    var methodInfo = type.GetMethod("ConvertXmlToClass");
                    if (methodInfo != null)
                    {
                        var method = methodInfo.MakeGenericMethod(itemType);
                        if (method != null)
                        {
                            object[] args = { doc, $"/{property.Name}/{itemType.Name}" };
                            object result = method.Invoke(null, args);
                            var r = result as IEnumerable<object>;
                            return r;
                        }
                    }
                }
            }
            return null;
        }
        private static bool IsEnumerable(PropertyInfo property)
        {
            var type = property.PropertyType;
            return typeof(IEnumerable).IsAssignableFrom(type) && type.IsGenericType;
        }
        private static object GetNodeValue(XmlNode node, string nodeName)
        {
            if (node[nodeName] != null)
            {
                var i = node[nodeName].InnerText;
                return i;
            }
            return null;
        }
    }
