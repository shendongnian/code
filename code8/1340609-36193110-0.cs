    string toParse = "A-B-C-D";
    char[] toParseChars = toPase.toCharArray();
    string result = "";
    string binary;
    for(int i = 0; i < (int)Math.pow(2, toParse.Length/2); i++) { // Number of subsets of an n-elt set is 2^n
        binary = Convert.ToString(i, 2);
        char[] binChars = binary.ToCharArray();
        for (int k = 0; k < binChars.Length; k++) {
            if (binChars[k] == '1') {
                result += toParseChars[k*2].ToString();
                result += "-";
            }
            else {
                result += toParseChars[k*2].ToString();
            }
        }
    }
