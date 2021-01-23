    public static class AmazingFactory {
        private static IDictionary<int, Type> _num2Type;
        
        private static void InitializeFactory() {
            var type = typeof(BaseClass);
            // get all subclasses of BaseClass 
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            
            foreach(var type in types) {
                int numberAtTheEnd = int.Parse(Regex.Match(type.Name, @"\d+$").Value);
                _num2Type[numberAtTheEnd] = type;
            }
        }
        
        public static BaseClass Create(int num) {
            if (_num2Type == null)
                InitializeFactory();
            
            return (BaseClass)Activator.CreateInstance(_num2Type[num]);
        }
    }
