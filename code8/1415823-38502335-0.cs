    namespace FruitListTest
    {
        class Fruit { }
        class Apple : Fruit { }
        
        class Program
        {
            static List<Fruit> fruitList = new List<Fruit>();
    
            public static void GetSpecificFruits<specificFruit>(List<specificFruit> specificFruits) 
                where specificFruit : Fruit
            {
                foreach (var fruit in fruitList)
                {
                    var fruitAsT = fruit as specificFruit;
                    if (fruitAsT != null)
                        specificFruits.Add(fruitAsT);
                }
            }
    
            static void Main(string[] args)
            {
                List<Apple> applesInFruits = new List<Apple>();
                GetSpecificFruits(applesInFruits);
            }
        }
    }
