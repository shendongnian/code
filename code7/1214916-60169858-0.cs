    public void TheFunction (string param1, string param2)
    {
      [...] //processing stuff
    }
    public void TheFunction (string param1)
    {
       return TheFunction(param1, String.Empty);
    }
      
