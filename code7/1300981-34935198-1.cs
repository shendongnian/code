     public void MyMethod()
     {
         // Sample object with underlying type as IEnumerable
         object obj1 = new ArrayList();
    
         // Sample object with underlying type as IEnumerable & IEnumerable<T>
         object obj2 = (IList<string>)new List<string>();
    
            if (typeof(IEnumerable).IsAssignableFrom(obj1.GetType()))
            {
                if (!obj1.GetType().IsGenericType)
                {
                    // Handles case of IEnumerable
                    Test((IEnumerable)obj1);
                }
                else
                {
                    // Handles case of IEnumerable<T>
                    InvokeGenericTest(obj2);
                }
            }
     }
    
     public void Test(IEnumerable source)
     {
         Console.WriteLine("Yes it was IEnumerable.");
     }
    
    
     public void Test<T>(IEnumerable<T> source)
     {
         Console.WriteLine("Yes it was IEnumerable<{0}>.", typeof(T));
    
         // Use linq with out worries.
         source.ToList().ForEach(x => Console.WriteLine(x));
     }
    
     /// <summary>
     /// Invokes the generic overload of Test method.
     /// </summary>
     /// <param name="source"></param>
     private void InvokeGenericTest(object source)
     {
         Type t = source.GetType();
    
         var method = this.GetType().GetMethods().Where(x => x.IsGenericMethod && x.Name == "Test").First();
    
         var genericMethod = method.MakeGenericMethod(t.GenericTypeArguments.First());
         genericMethod.Invoke(this, new object[] { source });
     }
