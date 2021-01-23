      delegate void DelMethod();
    
            void Method() { }
    
            void MethodTwo() { }
    
            private void MyMethod()
            {
    
                DelMethod x;
    
                x = condition == true ? (DelMethod)Method : (DelMethod)MethodTwo;
    
            }
