    private static string frame;
    public static void writeLine(string s) {
        frame += s + Environment.NewLine; //I believe "\n" works too
    }
    public static void write(string s) {
        frame += s;
    }
    public static void clearFrame() { frame = ""; }
    public static void drawFrame() {
        Console.Clear();
        DisplayStats();
        Console.WriteLine(frame);
    }
    public static void DisplayStats() {
        Console.WriteLine("Player Health: " + playerHealthUpgraded + "\tMonster Health: " + monsterHealth);
        Console.WriteLine("Player Attack: " + playerAttackUpgraded + "\tMonster Attack: " + monsterAttack);
        Console.WriteLine("");
    }
