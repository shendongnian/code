        static void Main(string[] args)
        {
            Type modelType = GetMyType();
            var myList = Activator.CreateInstance(modelType);
            var listInnerType = modelType.GetGenericArguments()[0];
            var listInnerTypeObject = Activator.CreateInstance(listInnerType);
            var addMethod = modelType.GetMethod("Add");
            addMethod.Invoke(myList, new[] { listInnerTypeObject });
        }
        static Type GetMyType()
        {
            return typeof(List<>).MakeGenericType((new Random().Next(2) == 0) ? typeof(A) : typeof(B));
        }
    class A { }
    class B { }
