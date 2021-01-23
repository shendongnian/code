     public class Player
     {
          public string Name;
     }
      int i; // This is the same as int i = 0 as default(int) == 0
      i.ToString(); // does not crash as i has a default value;
      Player p; // This is a reference type, the value fo default(Player) is null
      p.ToString(); // This will crash with a NullReferenceException as p was never initialized and you're effectivelly calling a method on "null".
