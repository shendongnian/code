        private static List<dynamic> callingprogram2(List<Item> paramss)
        {
            dynamic newList = new List<dynamic>();
            foreach (var item in paramss)
            {
                dynamic dObject = new ExpandoObject();
                dObject.a = item.a;
                dObject.b = item.b;
                if (item.c != 0.0)
                {
                    dObject.c = item.c;
                }
                newList.Add(dObject);
            }
            
            return newList;
        }
