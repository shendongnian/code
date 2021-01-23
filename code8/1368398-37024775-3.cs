    public class MyClass
        {
            
            private int MethodA()
            {
                int varA = GetSingleValesFromDB()
                // do other this using varA
                // then return
                return varA;
            }
    
            private void MethodB()
            {
               int varB = MethodA(); // this case varA will assign to varB
               // then use varB for anything
            }
        }
