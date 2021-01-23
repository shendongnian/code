    class Solution {
    public int lowest=1;
    public int solution(int[] A) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        if (A.Length < 1)
            return 1;
         for (int i=0; i < A.Length; i++){
             if (A[i]==lowest){
                lowest++;
                solution(A);
             }
         }
         
         return lowest;  
        }
    }
