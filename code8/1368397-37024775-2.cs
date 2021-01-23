    public class MyClass
        {
            
            private int MethodA()
            {
                return GetSingleValesFromDB();
            }
    
            private void MethodB()
            {
               int varA = MethodA();
            }
        }
