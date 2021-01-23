    var asm = Assembly.GetExecutingAssembly();
    
    var x=asm.GetTypes()
      .Where(type => typeof(Controller).IsAssignableFrom(type)) //filter controllers
      .Where(controller=>controller.CustomAttributes.Any(ca=>ca.AttributeType.Name=="TranslateFilter"))
      .Where(controller=>controller.Name!="Translation")
      .SelectMany(type => type.GetMethods())
      .Where(method => method.IsPublic && !method.IsDefined(typeof(NonActionAttribute)))
      .Where(method=>method.ReturnType.Name=="ActionResult")
      .Where(method=>method.CustomAttributes.All(ca => ca.AttributeType.Name != "HttpPostAttribute"))
      .Select(t=>new {Action=t.Name,Controller=t.ReflectedType.Name.Replace("Controller", "")});
