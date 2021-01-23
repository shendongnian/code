    class Weapon1 
    {
       public Type Ability = typeof(ExampleAbilityClassName);
    }
    
    class Weapon2 
    {
       public Type Ability = typeof(OtherAbilityClassName);
    }
    
     class Character : MonoBehaviour
     {
        Weapon1 foo = new weapon1();
        Weapon2 boo = new weapon2();
        void useAbility () 
        {
           gameObject.AddComponent(foo.Ability);
           gameObject.AddComponent(boo.Ability);
        }
      }
