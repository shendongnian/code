    Debug.Log ("Current number of weapons in character's inventory: " + char_inv_weapon.Count + ". Check all item details in Unity Editor's Inspector on the right. Below see a list of weapons:");
    var weaponService = new WeaponService();
                foreach (Weapon weapon in char_inv_weapon) {
                    Debug.Log ("Weapon name and description plus rolled damage:  " + weapon.name + ":  " + weapon.description + " Rolled damage: " + weaponService.GetDamageRoll(weapon)
                }
    public class WeaponService{
    
    public int GetDamageRoll(object wpn){
    if(wpn.name == "LongSword"){
    return 49;
    }
    else{
    ...
    }
    }
    }
