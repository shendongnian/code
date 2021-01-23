    //go to the file and extract the X and Y points
    StreamReader file = new StreamReader(openFileDialog1.OpenFile());
    string line = "";
    Series filePoints = new Series();
    while ((line = file.ReadLine()) != "")
    {
        //find the dot so that you know were to split the string
        int split = line.IndexOf(".");
        float X = float.Parse(line.Substring(0, split)),
            Y = float.Parse(line.Substring(split + 1, line.Length - (split + 1)));
        //add the points
        filePoints.Points.AddXY(X, Y);
    }
