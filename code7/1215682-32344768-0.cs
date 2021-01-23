    class Weapon1 : MonoBehvaiour
    {
    }
    
    class Character : MonoBehaviour
    {
        void useAbility()
        {
            gameObject.AddComponent<Weapon1>();
        }
    }
