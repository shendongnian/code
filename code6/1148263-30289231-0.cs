        public void CallMethod(string d, string n)
        {
            object dynamicObject;
            // Here I want to call the method named n in the dynamic d
            string objectClass = "yourNamespace.yourFolder." + d;
            Type objectType = Type.GetType(objectClass);
            if (objectType == null)
            {
                // Handle here unknown dynamic objects
            }
            else
            {
                // Call here the desired method
                dynamicObject = Activator.CreateInstance(objectType);
                System.Reflection.MethodInfo method = objectType.GetMethod(n);
                if (method == null)
                {
                    // Handle here unknown method for the known dynamic object
                }
                else
                {
                    object[] parameters = new object[] { };   // No parameters
                    method.Invoke(dynamicObject, parameters);
                }
            }
        }
