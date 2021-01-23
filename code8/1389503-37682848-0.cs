    var x1 = Assembly.GetExecutingAssembly()
               .GetTypes()
               .Where(type=>!type.IsDefined(typeof(CompilerGeneratedAttribute), false))
               .Select(type => type
                  .GetCustomAttributes(false)
                  .Select(attribute => type.Name + " - " + attribute.ToString())
                  .ToList())
               .ToList();
                x1.ForEach(type => type.ForEach(Console.WriteLine));
