      if (Request.IsAuthenticated)
      {
    ...
 
    // We don't need to validate user fields if user is logged in.
    ModelState.Remove("CommenterName");
    ModelState.Remove("Email");
     }
