       private string combinedString(string[] pieces)
       {
        string alltogether = "";
        for (int index = 0; index <= pieces.Length - 1; index++) {
            if (index != pieces.Length - 1) {
                 alltogether += string.Format("{0}/" pieces[index]);
            }
        }
        return alltogether;
