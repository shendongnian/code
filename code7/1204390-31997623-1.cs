      class CProjectReflector
        {
            private List<CProjectObject> _projectObjects;
    
            public List<CProjectObject> ProjectObjects 
            {
                get { return _projectObjects; }
                set { _projectObjects = value; }
            }
    
            public CProjectReflector()
            {
                _projectObjects = new List<CProjectObject>();
    
                foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    CProjectObject obj = CProjectObject.CreateProjectObjectWithName(type.Name);
                    FillProperties(type, obj);
                    FillFields(type, obj);
                    FillMethods(type, obj);
                    FillMembers(type, obj);
                    FillEvents(type, obj);
                    _projectObjects.Add(obj);
                }
            }
    
            private static void FillEvents(Type type, CProjectObject obj)
            {
                foreach (EventInfo eventInfo in type.GetEvents())
                {
                    obj.Events.Add(eventInfo.Name);
                }
            }
    
            private static void FillMembers(Type type, CProjectObject obj)
            {
                foreach (MemberInfo memberInfo in type.GetMembers())
                {
                    obj.Members.Add(memberInfo.Name);
                }
            }
    
            private static void FillMethods(Type type, CProjectObject obj)
            {
                foreach (MethodInfo methodInfo in type.GetMethods())
                {
                    obj.Methods.Add(methodInfo.Name);
                }
            }
    
            private static void FillFields(Type type, CProjectObject obj)
            {
    
                foreach (FieldInfo fieldInfo in type.GetFields())
                {
                    obj.Fields.Add(fieldInfo.Name);
                }
            }
    
            private static void FillProperties(Type type, CProjectObject obj)
            {
                foreach (PropertyInfo propertyInfo in type.GetProperties())
                {
                    obj.Properties.Add(propertyInfo.Name);
                }
            }
    
            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();
                foreach (CProjectObject obj in _projectObjects) 
                {
                    builder.AppendLine(obj.ToString());
                }
                return builder.ToString();
            }
    
        }
