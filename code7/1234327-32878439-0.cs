    public class Ability {
        public int Score { get; set; }
        public Ability(int score) {
            Score = score;
        }
    }
    public static void KillReference(Ability ability) {
        // When we execute the next line, the ability
        // from the original scope will stay the same
        ability = new Ability(2);
    }
    public static void Main() {
        Ability ability = new Ability(5);
        KillReference(ability);
        // ability.Score is still 5
    }
