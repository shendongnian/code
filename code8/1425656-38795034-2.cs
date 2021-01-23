    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var diceRolls = new DiceRolls();
                var inventory = new CharacterInventory();
    
                inventory.Add_to_inventory(new Weapon("Longsword",
                    "Most popular type of sword, weapon of choice for many warriors and mercenaries.", false, 15, "gp", 3,
                    "Longsword", "1d8", "slashing", diceRolls.Rolld8(), new List<string>() { "Versatile (1d10)" }));
                inventory.Add_to_inventory(new Weapon("Shortsword",
                    "Sharp, lightweight, piercing weapon commonly used by shorter races and rogues.", false, 10, "gp", 2,
                    "Shortsword", "1d6", "piercing", diceRolls.Rolld6(), new List<string>() { "Light", "Finesse" }));
                inventory.Add_to_inventory(new Weapon("Quarterstaff",
                    "Long, blunt staff, typically made of wood. Common for wanderers, travellers, seen in use by wizards, druids and monks.",
                    false, 2, "sp", 4, "Quarterstaff", "1d6", "blunt", diceRolls.Rolld6(),
                    new List<string>() { "Versatile (1d8)" }));
    
    
                // Debug: Count current inventory items and list them in Console via foreach loop
    
                Console.WriteLine("Current number of weapons in character's inventory: " + inventory.char_inv_weapon.Count +
                                  ". Check all item details in Unity Editor's Inspector on the right. Below see a list of weapons:");
                foreach (Weapon weapon in inventory.char_inv_weapon)
                {
                    Console.WriteLine("Weapon name and description plus rolled damage:  " + weapon.name + ":  " +
                                      weapon.description + " Rolled damage: " + weapon.dmg_roll);
                }
    
                Console.WriteLine("Current number of weapons in character's inventory: " + inventory.char_inv_weapon.Count +
                                  ". Check all item details in Unity Editor's Inspector on the right. Below see a second roll of list of weapons:");
                foreach (Weapon weapon in inventory.char_inv_weapon)
                {
                    Console.WriteLine("Weapon  and description plus damage rolled second time:  " + weapon.name + ":  " +
                                      weapon.description + " Rolled damage: " + weapon.dmg_roll);
                }
            }
        }
    
    
    
        [System.Serializable]
        public class Item : IComparable<Item>
        {
            public string name, description;
            public bool stackable;
            public int value;
            public string coin_type;
            public int weight;
            //  public string model_path;
    
            public Item(string c_name, string c_description, bool c_stackable, int c_value, string c_coin_type, int c_weight)
            {
                name = c_name;
                description = c_description;
                stackable = c_stackable;
                value = c_value;
                coin_type = c_coin_type;
                weight = c_weight;
                //  model_path = c_model_path;
                //, string c_model_path)
            }
    
            public int CompareTo(Item other)
            {
                return String.Compare(name, other.name);
            }
        }
    
        [System.Serializable]
        public class Weapon : Item, IComparable<Weapon>
        {
            public string weapon_prof;
            public string dmg_die;
            public string dmg_type;
            public int dmg_roll;
            public List<string> weapon_properties;
    
            public Weapon(string c_name, string c_description, bool c_stackable, int c_value, string c_coin_type,
                int c_weight, string c_weapon_prof, string c_dmg_die, string c_dmg_type, int c_dmg_roll,
                List<string> c_weapon_properties) : base(c_name, c_description, c_stackable, c_value, c_coin_type, c_weight)
            {
                weapon_prof = c_weapon_prof;
                dmg_die = c_dmg_die;
                dmg_type = c_dmg_type;
                dmg_roll = c_dmg_roll;
                weapon_properties = c_weapon_properties;
            }
    
            public int CompareTo(Weapon other)
            {
                return String.Compare(name, other.name);
            }
        }
    
    
        public class CharacterInventory
        {
            public List<Weapon> char_inv_weapon;
            public List<object> char_inv_armor;
            public List<object> char_inv_potion;
            public List<Item> char_inv_other;
    
    
            public CharacterInventory()
            {
                char_inv_weapon = new List<Weapon>();
                char_inv_armor = new List<object>();
                char_inv_potion = new List<object>();
                char_inv_other = new List<Item>();
            }
    
            // Sorting
    
            public void Add_to_inventory(Item it)
            {
                if (it is Weapon)
                {
                    char_inv_weapon.Add((Weapon) it);
                    char_inv_weapon.Sort();
                }
                //else if (it is Armor)
                //{
                //    char_inv_armor.Add((Armor) it);
                //    char_inv_armor.Sort();
                //}
                //else if (it is Potion)
                //{
                //    char_inv_potion.Add((Potion) it);
                //    char_inv_potion.Sort();
                //}
                else
                {
                    char_inv_other.Add(it);
                    char_inv_other.Sort();
                }
            }
        }
    
        internal class DiceRolls
        {
            public int Rolld8()
            {
                Random rnd1 = new Random();
                var d8 = rnd1.Next(1, 9);
                return d8;
            }
    
            public int Rolld6()
            {
                Random rnd1 = new Random();
                var d6 = rnd1.Next(1, 7);
                return d6;
            }
        }
    }
