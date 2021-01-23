    var typeList = Enum.GetValues(typeof(Type))
                   .Cast<Type>()
                   .Select(t => new TypeViewModel
                   {
                       Id = ((int)t),
                       Name = t.ToString()
                   });
