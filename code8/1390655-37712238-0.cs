    public class Ship : MonoBehaviour 
    {
        public Ship()
        {
             weaponsList = new List<Weapon>();
        }
        public List<Weapon> weaponsList;
        void Start()
        {
            weaponsList = new List<Weapon>();
            weaponsList.Add(new Weapon());
            weaponsList.Add(new Weapon());
        }
    }
