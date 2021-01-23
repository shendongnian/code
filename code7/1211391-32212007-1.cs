    public static class ClassContracts {
       public static void ThrowIfNull(this Object item)
       {
           if(item == null) throw new XamlParseException("Your message here", null); 
       }
    
    }
