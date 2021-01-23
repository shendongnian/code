    public abstract class Animal
    {
         public void Sleep() { .... }
         
         public Animal Eat()
         {
             OnEat();
             Sleep();
         }
         public Animal Play();
         {
             OnPlay();
             Sleep();
         }
         protected abstract Animal OnEat();
         protected abstract Animal OnPlay();
    }
