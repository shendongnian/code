    class Solution {
    static int CalcBinary (int n) {
        int oldCount = 0, newCount = 0;
        Stack<int> binRep = new Stack<int>();
        while (n > 0) {
            int i = n%2;
            binRep.Push (i);
            n = n/2;
            if (i == 1) {
                newCount++;
            }
            else {
                if (newCount > oldCount) {
                    oldCount = newCount;
                    newCount = 0;
                }
            }
            
        }
        return (newCount > oldCount) ? newCount : oldCount;
    }
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine (CalcBinary(n));
    }
