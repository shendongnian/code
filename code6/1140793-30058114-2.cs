    @if(!string.IsNullOrEmpty((string)HttpContext.Current.Session["PersonSession"]))
    {
      Person newPerson = new Person();
    }
    else
    {
      Person newPerson = (Person)HttpContext.Current.Session["PersonSession"];
    }
