    public class SomewhatEvilDog: Animal
    {
         protected override Animal OnEat() { ... }
         protected override Animal OnPlay() { ... }
         public new Animal Eat() { OnEat(); }
         public new Animal Play() { OnPlay(); }
    }
