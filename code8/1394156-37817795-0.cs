        private static void CreateApis()
        {
            var classes = GetArrayOfClassInstances();
            
            foreach (KeyValuePair<int, Type> instance in classes)
            {
                Type apiType = typeof(Api<>).MakeGenericType(instance.Value);
                var api = Activator.CreateInstance(apiType, new[]{typeof(System.Net.EndPoint)});
            }
        }
