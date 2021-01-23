    public class ClassProxy : IClass
    {
        void Method(Object context)
        {
           if (context.HasBilling) 
              new Class1().Method(context);
           else
            //etc
        }
    }
