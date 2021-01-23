    string input = "\n\n\n\n\nHi\n\n\n";
    string [] split = input.Split('\n');
    int prevN = -1, nextN = -1;
    for (int i = 0; i < split.Length; i++) {
         if (!String.IsNullOrEmpty(split[i])) {
            prevN = i - 1;
            nextN = i + split[i].Length;
            break;
        }
    }
    Console.WriteLine(prevN + "-" + nextN);
