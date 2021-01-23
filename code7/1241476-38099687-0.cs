    class Solution {
    int eq;
    public int solution(int[] A) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        for (int i = 0; i < A.Length; i++)
            {
                eq = A[i] + eq;
            }    
        return eq;
     }
    }
