    int start = 0, end = 0;
    for (var i = input.Length - 1; i >= 0; i--) {
        if (char.IsDigit(input[i]))
        {
            end = i + 1;
            while (i >= 0 && char.IsDigit(input[i])) i--;
            start = i + 1;
            break;
        }
    }
    var number = input.Substring(start, end - start);
