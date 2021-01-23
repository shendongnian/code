    public class Player : MonoBehaviour
    {
        public string Name;
        public float Health;
        public float Armor;
        void Reset()
        {
            Name = "UNKNOWN";
            Health = 100;
            Armor = 0;
        }
    }
