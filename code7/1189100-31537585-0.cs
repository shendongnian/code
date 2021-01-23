        public static object GetComObject(string typeName)
        {
            Type ComType;
            ComType = Type.GetTypeFromProgID(typeName);
            if (ComType == null)
            {
                //COM type not found
            }
            // Create an instance of your COM Registered Object.
            return Activator.CreateInstance(ComType);
        }
