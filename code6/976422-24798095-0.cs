    class Logic
    {
       public static Logic Instance
       {
          get
          {
              if (HttpContext.Current.Session["LogicInstance"] == null)
                  HttpContext.Current.Session["LogicInstance"] = new Logic();
              return (Logic) HttpContext.Current.Session["LogicInstance"];
          }
       }
       
       public string TextForSpan {get;}
       // The rest of your implementation
    }
