    public class Character
    {
        public int Health;
        public int Mana;
        public int MoveSpeed;
        public static Character FromString(string characterData)
        {
            MatchCollection matches = Regex.Matches(characterData, "[A-Za-z]+: ([\\d]+)");
            Character myCharacter = new Character();
            myCharacter.Health = Convert.ToInt32(matches[0].Groups[1].Value);
            myCharacter.Mana = Convert.ToInt32(matches[1].Groups[1].Value);
            myCharacter.MoveSpeed = Convert.ToInt32(matches[2].Groups[1].Value);
            return myCharacter;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Character myCharacter = Character.FromString("Health: 100 Mana: 110 MoveSpeed: 120");
        }
    }
