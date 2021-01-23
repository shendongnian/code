    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            var weightLambda = program.DoInternal("Weight").ToString() 
                == "(Param_0, Param_1) => (Convert(Param_0).Weight = Convert(ChangeType(Param_1, System.Object)))";
            var goodiesLambda = program.DoInternal("Goodies").ToString()
                == "(Param_0, Param_1) => (Convert(Param_0).Goodies = Convert(ChangeType(Param_1, ConvertParcelFeat(Param_1, \"Goodies\"))))";
            Console.WriteLine("WeightLambda is Ok: {0}\nGoodiesLambda is Ok: {1}", weightLambda, goodiesLambda);
        }
        public Action<Object, Object> Do(string name)
        {
            return DoInternal(name).Compile();
        }
        public Expression<Action<object, object>> DoInternal(string name)
        {
            var info = new {Name = name, Type = typeof(Program)};
            var propertyInfo = info.Type.GetProperty(info.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            var objParameter = Expression.Parameter(typeof(object));
            var valueParameter = Expression.Parameter(typeof(object));
            //This is the method call I'm trying to add
            Expression toBeTypeChanged;
            if (info.Name[0] == 'G' && info.Type.Name == "Program")
            {
                toBeTypeChanged = Expression.Call(ConvertParcelFeatMethod, valueParameter, Expression.Constant(info.Name));
            }
            else
            {
                toBeTypeChanged = Expression.Constant(propertyInfo.PropertyType);
            }
            var changeTypeCall = Expression.Call(ChangeTypeMethod, valueParameter, toBeTypeChanged);
            var objCast = Expression.Convert(objParameter, info.Type);
            var valueCast = Expression.Convert(changeTypeCall, propertyInfo.PropertyType);
            var property = Expression.Property(objCast, propertyInfo);
            var assignment = Expression.Assign(property, valueCast);
            return Expression.Lambda<Action<object, object>>(assignment, objParameter, valueParameter);
        }
        public object Weight { get; set; }
        public object Goodies { get; set; }
        public static object ChangeType(object valueParameter, object constant)
        {
            return null;
        }
        public static object ConvertParcelFeat(object valueParameter, object constant)
        {
            return null;
        }
        public MethodInfo ConvertParcelFeatMethod
        {
            get { return typeof(Program).GetMethod("ConvertParcelFeat"); }
        }
        public MethodInfo ChangeTypeMethod
        {
            get { return typeof(Program).GetMethod("ChangeType"); }
        }
    }
