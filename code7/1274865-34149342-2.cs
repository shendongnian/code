        public class Program
        {
            public void Main(string[] args)
            {
                // Number of moves by using only 1 or 2 moves
               Console.WriteLine("Enter a number of moves?");
               int myNumber = int.Parse(Console.ReadLine());
        
               GenerateMoves (myNumber);
               Console.WriteLine("Done...");
               Console.Read();
           }
           static void GenerateMoves(int n) {
               GenerateMoves (n, "");
           }
           static void GenerateMoves(int n, string permutation) {
               if (n==0) { System.Console.WriteLine (permutation); }
               else {
                   if (n>=1) { GenerateMoves (n-1, permutation + "1"); }
                   if (n>=2) { GenerateMoves (n-2, permutation + "2"); }
               }
           }
       }
    }
