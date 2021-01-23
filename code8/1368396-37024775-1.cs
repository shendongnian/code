      public class MyClass
        {
            private int varA = 0;
            private void MethodA()
            {
                varA = GetSingleValesFromDB();
            }
    
            private void MethodB()
            {
                Console.WriteLine(varA);
            }
        }
