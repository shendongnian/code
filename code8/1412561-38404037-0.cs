    class Animal {
        private float _age = 35;
        protected float Age {
           get {
             return this._age;
           }
        }
    }    
    class Cat {
        private float _gallonsOfMilkEaten;
        private Animal _animal = new Animal();
    
        public void Meow() {
             Debug.log("This dog ate "+_gallonsOfMilkEaten+" gallons of milk and is " + _animal.Age +" years old." )}
        }
    } 
    class Dog {
        private float _bonesBurried;
        private Animal _animal = new Animal();
    
        public void Woof() {
           //...
        }
    }
