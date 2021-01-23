    void GenerateMoves(int n, string permutation) {
        if (n==0) { System.Console.WriteLine (permutation); }
        else {
            if (n>=1) { GenerateMoves (n-1, permutation + "1"); }
            if (n>=2) { GenerateMoves (n-2, permutation + "2"); }
        }
    }
