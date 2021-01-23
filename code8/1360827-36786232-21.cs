    public string ABC<T>(T obj) where T : IDestination
    {
         ClassA a = obj as ClassA;
         ClassB b = obj as ClassB;
    
         // Now if you want to access Var1, Var2 you can access them
         // using "obj" reference, because T is IDestination
         string var1 = obj.Var1;
         string var2 = obj.Var2;
    
         if(a != null) 
         {
             // Here access all ClassA members...
         }
    
         if(b != null)
         {
             // Here access all ClassB members...
         }
    }
