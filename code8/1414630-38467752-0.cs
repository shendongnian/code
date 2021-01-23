    public static bool Seq_Check(int[] A, int k)
    {
        int n = A.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool inSequence = A[i] != 1 || A[i] == k;
            if (A[i] > A[i+1] || (A[i] == A[i+1] && inSequence))
                return false;
            }
             if ( A[0] != 1 && A[n-1] != k )
                 return false;
             else
                 return true;
             }
        }
    }
