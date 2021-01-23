    int[] input   = { 3, 0, 8, 3, 8, 1, 9, 1, 1 };
    int[] pattern = { 7, 3, 1, 7, 3, 1, 7, 3, 1 };
    int total = 0;
    for (int i = 0; i < input.Length; i++)
        total += input[i] * pattern[i];
    int check = total % 10;         // total = 142, check = 2
