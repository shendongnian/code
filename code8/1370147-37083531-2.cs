    // The character part of the argument: 15-length vector of characters:
    Chars = "A","A","B","D","C","B","A","C","D","C","A","B","A","A","D" 
    // From that, extract the locations of the unique characters:
    CharsA = 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0 // Where Chars == A
    CharsB = 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0 // Where Chars == B
    CharsC = 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0 // Where Chars == C
    CharsD = 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 // Where Chars == D
    // The numeric part of the argument: 15-length vector of numbers:
    // Btw, is this about lottery... hmmm
    Nums = 1, 2, 3, 4, 7, 12, 12, 14, 15, 22, 23, 25, 35, 36, 37
    :For Number :In [all numbers between 16384 and 32767]
        Base2 = [2-base of Number] // 20123 would give: 1 0 0 1 1 1 0 1 0 0 1 1 0 1 1
        // Test 1: "For each group, it can contains 1 - 4 elements"
            [using Base2, partition the partition vector Base2 itself;
             bail out if any partition length exceeds 4]
        // Test 2: "Difference between element must be <= 3"
            [using Base2, partition Nums; 
             check differences inside each partition; 
             bail out if bigger than 3 anywhere]
        // Test 3: "For each group, letter cannot be repeated"
            [using Base2, partition CharsA, CharsB, CharsC, CharsD (each in turn);
             count number of ones in each partition;
             bail out if exceeds 1 anywhere (meaning a character occurs more than once)]
        // If we still are here, this partition Number is ACCEPTABLE
        [add Number to a list, or do a parallel boolean marking 1 for Number]
    :End
