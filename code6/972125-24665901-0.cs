    string input = "Perfume Soap Random52\n" +
                   "Sample id: Random52\n" +
                   "Key: 1324354657\n" +
                   "Bubble Shampoo aRandom88\n" +
                   "Sample id: aRandom88\n" +
                   "Key: 1234567890\n" +
                   "BathSoda Monkey 101\n" +
                   "Sample id: Monkey 101\n" +
                   "Key: 0192837465";
    // split lines so each one is a different element of an Array
    string[] split2 = input.Split('\n');
    string output;
    for (int i = 1; i < split2.Count(); i += 3) {
    	output = split2[i - 1].Trim();
      // count number of words in first line (will use it later)
    	string[] wordsList = output.Split(' ');
    	int wordsCount = wordsList.Count();
      // combine lines 1 and 2 to begin duplicates removal process
    	output += " " + split2[i].Trim();
    	string[] split = output.Split(' ');
      // group elements together and filter duplicates
    var singles = split.GroupBy(x = > x).Where(g = > g.Count() == 1).SelectMany(g = > g);
      // number of words removed from first line
    	int cCount = (split.Count() - singles.Count()) / 2;
      // number of words remaining in first line after duplicate removal
    	int wCount = wordsCount - cCount;
    	output = string.Empty;
      // I don't know how to convert 'singles' type to array, so i did it my way
    	foreach(string f in singles) {
    		output += " " + f;
    	}
      // output should now have all words inside without duplicates
    
    	string[] oArray = output.Split(' '); // array full of output words
    	output = string.Empty;
      
      // add only names to output, as I requested
    	for (int c = 0; c <= wCount; c++)
    	{
    		output += oArray[c] + " ";
    	}
    
    	output = output.Trim(); // delete spaces around for cleaner looks
