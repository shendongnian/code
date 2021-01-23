    string[] lines = File.ReadAllLines(@"Text Document.txt");
    
    for(int i = 0; i < lines.Length(); i++){
        if(lines[i].Contains("XYZ")){
            string pass = "Pass";
            string date = line.Substring(0, 10);
            string time = line.Substring(11, 12);
            Console.WriteLine("\n\t" + pass + " Date: {0}\tTime: {1}", date, time);
            // Retrieve the value in the next line
            string nextLineAfterXYZ = lines[i + 1];
            batchID = currentLine.Substring(100);
            Console.WriteLine("\tBatchID{0}", batchID);
        }
    }
