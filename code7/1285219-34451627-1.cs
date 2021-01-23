      public class Minion
        {
            public int manaCost;
            public int attack;
            public int health;
            public string cardText;
            public Minion(int mana, int atk, int h, string txt)
            {
                manaCost = mana;
                attack = atk;
                health = h;
                cardText = txt;
            }
            public void displayStats(string name)
            {
                Console.WriteLine(name + "\nMana Cost: " + manaCost + "\nAttack: " + attack + "\nHealth: " + health + "\n" + cardText + "\n");
            }
        }
