    static void GetWidgetValue(MainClass obj)
        {
            Type[] typesThatHaveWidgetValue = new Type[] { typeof(ClassA), typeof(ClassB), typeof(ClassC) };
            if (typesThatHaveWidgetValue.Contains(obj.GetType()))
            {
                dynamic o = obj;
                Console.WriteLine(o.WidgetValue);
            }
            else
            {
                Console.WriteLine("Object don't have property 'WidgetValue'");
            }
        }
        static void GetWidgetValueWithReflection(MainClass obj)
        {
            var type = obj.GetType();
            var widgetValueProp = type.GetProperty("WidgetValue");
            if (widgetValueProp != null)
            {
                var widgetValue = widgetValueProp.GetValue(obj);
                Console.WriteLine(widgetValue);
            }
            else
            {
                Console.WriteLine("Object don't have property 'WidgetValue'");
            }
        }
