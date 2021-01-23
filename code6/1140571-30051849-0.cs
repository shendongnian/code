        static string GetTableNameFromType(Type type)
        {
            // what go here to get string of "Customer" for type = CustomerProxy
            //              to get string of "_USER" for type = UserRBACProxy
            TableBaseAttribute tableBaseA = (TableBaseAttribute)type.GetCustomAttributes(typeof(TableBaseAttribute), true)[0];
            string ret = null;
            if (string.IsNullOrEmpty(tableBaseA.Name))
            {
                do
                {
                    var attr = type.GetCustomAttributes(typeof(TableBaseAttribute), false);
                    if (attr.Length > 0)
                    {
                        return type.Name;
                    }
                    else
                    {
                        type = type.BaseType;
                    }
                } while (type != typeof(object));
            }
            else
            {
                ret = tableBaseA.Name;
            }
            return ret;
        }
