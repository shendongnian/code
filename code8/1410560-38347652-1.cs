    const string separator = ", ";
    var splitInput = input.Split(separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    var length = splitInput[0].Length;
    var targetIndex = 1;
    for (targetIndex = 1; length <= 140; targetIndex++)
        length += separator.Length + splitInput[targetIndex].Length;
    if (length > 140)
        targetIndex--;
    var splitOutput = new string[targetIndex];
    Array.Copy(splitInput, 0, splitOutput, 0, targetIndex);
    var output = string.Join(separator, splitOutput);
