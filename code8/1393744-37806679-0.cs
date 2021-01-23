      interface IAnimal // or class 
            {
             /*return type*/ GetDetails();
            }
            
            public static void displayAnimal<T>(ref T mammal) where T :IAnimal
                {
                    T ourMammal;
                    ourMammal =  mammal;
                    mammal.GetDetails();
                }
