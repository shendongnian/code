    private void BT_Xref_Click(object sender, EventArgs e)
    {
        //grabs file path from text box
        string ManifestPath = TB_Manifest.Text;
        //grabs parent directory from file path
        string directoryName = Path.GetDirectoryName(ManifestPath);
        //creates a new folder for the final output text file
        string pathString = Path.Combine(directoryName, "Final Index");
        Directory.CreateDirectory(pathString);
        //list for matching text lines which will eventually be output to the final text file
        List<string> NewData = new List<string>();
        String[] ManifestArray = File.ReadAllLines(ManifestPath);
        List<string> RemoveManifest = new List<string>(ManifestArray);
        String[] OutputArray = File.ReadAllLines(TB_Complete.Text);
        List<string> RemoveOutput = new List<string>(OutputArray);
        //initializes a count which decides at what point a text file should be created
        int shortcount = 0;
        //.ReadLine is initialized to ignore the first line in both text files
        string ManifestLine = ManifestReader.ReadLine();
        string OutputLine = OutputReader.ReadLine();
		Dictionary<string, Tuple<string, string>> ManifestMap = new Dictionary<string, Tuple<string, string>>();
		
        foreach (string mfile in ManifestArray.Skip(1))
        {
            string ManifestLine = mfile;
            string ManifestElement = ManifestLine.Split(',')[6];
            string ManifestElement2 = ManifestLine.Split(',')[5];
            //value to be retreived and output to final text file
            string ManifestElementDate = ManifestElement2.Replace("/", "-");
            //value to be compared with the other text file
            string ManifestNoExt = Regex.Replace(ManifestElement, ("(\\.\\w+$)"),"");
			
			ManifestMap.Add(ManifestNoExt, Tuple.Create(ManifestElementDate, ManifestLine));
            //counting the mfile position in the ManifestArray
            //int removeIndex = Array.IndexOf(ManifestArray, mfile);
            //remove by resising the array
            //Array.Resize(ref ManifestArray, ManifestArray.Length - 1);
		}
		
		foreach (string ofile in OutputArray.Skip(1))
		{
			//value to be compared with other text file
			string OutputElement = OutputLine.Split('|')[2];
			//if values equal then add the specified line of text to the list.
			if (ManifestMap.ContainsKey(OutputElement))
			{
				NewData.Add(OutputLine + "|" + ManifestMap[OutputElement].Item1);
				RemoveManifest.RemoveAll(item => item == ManifestMap[OutputElement].Item2);
				if (NewData.Count == 1000)
				{
					//if youve reached the count then output files into a new text file
					shortcount = shortcount + 1;
					File.WriteAllLines(pathString + "\\test" + shortcount + ".txt", NewData);
					NewData.Clear();
				}
				break;
			}
		}
        //once all line of text have been searched combine all text files in directory
        shortcount = shortcount + 1;
        File.WriteAllLines(pathString + "\\test" + shortcount + ".txt", NewData);
        String[] SplitTextFiles = Directory.GetFiles(pathString, "*.*", SearchOption.AllDirectories);
        using (var FinalIndexFile = File.Create(pathString + "\\FinalIndex.txt"))
        {
            foreach (var file in SplitTextFiles)
            {
                using (var input = File.OpenRead(file))
                {
                    input.CopyTo(FinalIndexFile);
                }
                File.Delete(file);
            }
        }
        //File.WriteAllLines("\\test.txt", Directory.EnumerateFiles(pathString, @"*.txt").SelectMany(file => File.ReadLines(file)));
    }
