    public static ModelBindingResult Success(string key, object model)
    {
       if (key == null)
       {
          throw new ArgumentNullException(nameof(key));
       }
    
       return new ModelBindingResult(key, model, isModelSet: true);
    }
