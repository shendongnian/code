      public class Minion
        {
            public readonly string name;
            public int manaCost;
            public int attack;
            public int health;
            public string cardText;
            public Minion(string name, int mana, int atk, int h, string txt)
            {
                this.name = name;
                this.manaCost = mana;
                this.attack = atk;
                this.health = h;
                this.cardText = txt;
            }
            public void displayStats()
            {
                Console.WriteLine(name + "\nMana Cost: " + manaCost + "\nAttack: " + attack + "\nHealth: " + health + "\n" + cardText + "\n");
            }
        }
