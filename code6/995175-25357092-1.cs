        [HttpPost]
        public ActionResult SaveRule(int? id, ExpandoObject ruleObj, string ruleTypeName)
        {
            Type type = GetTypeFromName(ruleTypeName);
            var instance = Activator.CreateInstance(type);
            foreach (var prop in type.GetProperties())
            {
                object val;
                ((IDictionary<string, object>)ruleObj).TryGetValue(prop.Name, out val);
                val = AutoMapObjectType(prop, val);
                prop.SetValue(instance, val);
            }
            var serialiser = new XmlSerializer(type);
            var sb = new StringBuilder();
            serialiser.Serialize(new StringWriter(sb), instance);
            if (id != null)
            {
                RuleDataAccess.SaveRule((int)id, sb.ToString()); 
            }
            return new JsonResult();
        }
        public static object AutoMapObjectType(PropertyInfo prop, object val)
        {
            if (prop.PropertyType.BaseType.Name == "Enum")
            {
                return Enum.Parse(prop.PropertyType, val.ToString());
            }
            else
            {
                switch (prop.PropertyType.Name)
                {
                    case "Boolean":
                        return Convert.ToBoolean(short.Parse(val.ToString()));
                    case "String":
                    case "Int32":
                    case "Decimal":
                        return Convert.ChangeType(val, prop.PropertyType);
                    default:
                        return Convert.ChangeType(val, prop.PropertyType); //Attempt to convert with implicit casting/conversion, (will fail if explicit cases are not handled)
                }
            }
        }
