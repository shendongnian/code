        public static object CallFunction(string method, string typeName, params object[] args)
        {
            Type ComType;
            object ComObject;
            ComType = Type.GetTypeFromProgID(typeName);
            if (ComType == null)
            {
                //COM type not found
            }
            // Create an instance of your COM Registered Object.
            ComObject = Activator.CreateInstance(ComType);
            // Call the Method and cast return to whatever it should be.
            return ComType.InvokeMember(method, BindingFlags.InvokeMethod, null, ComObject, args);
        }
