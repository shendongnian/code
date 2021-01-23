    public class Ship : MonoBehaviour 
    {
        public List<Weapon> weaponsList { get; private set; }
        public Ship()
        {
            weaponsList = new List<Weapon>();
        }
        ...
    }
