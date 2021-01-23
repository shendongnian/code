    public static void Increment(this object o, string propertyName)  
        {
            var property = o.GetType().GetProperty(propertyName);
            
            if (property == null)
                return;
            var val = property.GetValue(o, null);
            var op_Inc = o.GetType().GetMethod("op_Increment");
            if(op_Inc != null)
            {
                var val2 = op_Inc.Invoke(val, null);
                property.SetValue(o,val2);
            }
            switch (Type.GetTypeCode(property.PropertyType))
            {
                case TypeCode.UInt16:
                {
                    var x = (UInt16)val;
                    x++;
                    property.SetValue(o, x);
                }
                    break;
                case TypeCode.UInt32:
                    {
                        var x = (UInt32)val;
                        x++;
                        property.SetValue(o, x);
                    }
                    break;
                case TypeCode.UInt64:
                    {
                        var x = (UInt64)val;
                        x++;
                        property.SetValue(o, x);
                    }
                    break;
                case TypeCode.Int16:
                    {
                        var x = (Int16)val;
                        x++;
                        property.SetValue(o, x);
                    }
                    break;
                case TypeCode.Int32:
                    {
                        var x = (Int32)val;
                        x++;
                        property.SetValue(o, x);
                    }
                    break;
                case TypeCode.Int64:
                    {
                        var x = (Int64)val;
                        x++;
                        property.SetValue(o, x);
                    }
                    break;
                case TypeCode.Decimal:
                    {
                        var x = (Decimal)val;
                        x++;
                        property.SetValue(o, x);
                    }
                    break;
                case TypeCode.Double:
                    {
                        var x = (Double)val;
                        x++;
                        property.SetValue(o, x);
                    }
                    break;
                case TypeCode.Single:
                    {
                        var x = (Single)val;
                        x++;
                        property.SetValue(o, x);
                    }
                    break;
                 
            }
            
        }
    }
    public class Example
    {
        public static void Main()
        {
            var plane = new Plane(){DistanceTravelled = 0, PlaneAge = 0};
            Console.WriteLine("Before invoking increment: dist = {0}, age = {1}", plane.DistanceTravelled, plane.PlaneAge);
            plane.Increment("DistanceTravelled");
            plane.Increment("PlaneAge");
            Console.WriteLine("After invoking increment: dist = {0}, age = {1}", plane.DistanceTravelled, plane.PlaneAge);
            Console.ReadKey();
        }
    }
    public class Plane
    {
        public int DistanceTravelled { get; set; }
        public int PlaneAge { get; set; }
    }
