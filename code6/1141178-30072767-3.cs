    string[] testDepartments = new string[]
    {
        "Radio-Electronic Systems and Devices in Radioelectronics and laser technologies department",
        "Laser and Optic-Electronic Systems in Radioelectronics and laser technologies department",
        "Optic-Electronic Devices for Scientific Research in Radioelectronics and laser technologies department",
        "Theoretical Bases of Electrotechnology in Radioelectronics and laser technologies department",
        "Technologies of Instrument Making in Radioelectronics and laser technologies department"
    };
    int longestCommonPostfixIndex = 0;
    string firstString = testDepartments.First();
    // TODO: change to binary searching
    // TODO: check every string's length
    while(testDepartments.All(td => td.Substring(td.Length - longestCommonPostfixIndex) == firstString.Substring(firstString.Length - longestCommonPostfixIndex)))
         longestCommonPostfixIndex++;
    string res = string.Join(", ", testDepartments.Select(d => d.Substring(0, d.Length - longestCommonPostfixIndex + 1))) + firstString.Substring(firstString.Length - longestCommonPostfixIndex);
