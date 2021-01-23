    if (HttpContext == null) 
      throw new ArgumentNullException("HttpContext");
    if (HttpContext.User == null) 
      throw new ArgumentNullException("HttpContext.User"); 
    if (HttpContext.User.Identity == null) 
      throw new ArgumentNullException("HttpContext.User.Identity");
