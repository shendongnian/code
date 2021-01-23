    int check = 0;
    foreach (var c in input)
    {
        if (c == '(') {
            check++;
        } else if (c == ')') {
            check--;
        }
        if (check < 0) {
            return false; // error, closing bracket without opening brackets first
        }
    }
    return check == 0; // > 0 error, missing some closing brackets
