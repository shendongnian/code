      foreach (var item in ViewData.ModelState.Keys)
                {
                    int err=ViewData.ModelState[item].Errors.Count();
                    if (err.Equals(1))
                    {
                      // Add property name in a list 
                    }
                }
