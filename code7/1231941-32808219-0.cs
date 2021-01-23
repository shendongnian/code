    MemberInfo property = typeof(ExternalLoginConfirmationViewModel).GetProperty(s); 
    var dd = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
    if(dd != null)
    {
      var name = dd.Name;
    }
           
