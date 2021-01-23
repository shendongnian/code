    var interfaceType = ...
    var typeInQuestion = ...
    foreach(var interfaceMember in interfaceType.GetMembers().OfType<IMethodSymbol>())
    {
      var memberFound = false;
      foreach(var typeMember in typeInQuestion .GetMembers().OfType<IMethodSymbol>())
      {
        if (typeMember.Equals(typeInQuestion.FindImplementationForInterfaceMember(interfaceMember)))
        {
          // this member is found
          memberFound = true;
          break;
        }
      }
      if (!memberFound)
      {
        return false;
      }
    }
    return true;
