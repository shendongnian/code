    public class Ship : MonoBehaviour 
    {
        public List<Weapon> weaponsList;
    
        public Ship()
        {
            weaponsList = new List<Weapon>();
            weaponsList.Add(new Weapon());
            weaponsList.Add(new Weapon());
        }
    }
