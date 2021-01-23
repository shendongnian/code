    static void salesReport() {
        string path =  "sales.txt";
        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        StreamReader salesReport = new StreamReader(fs);
        string inputText = salesReport.ReadLine();
        Console.WriteLine("{0,-15}{1,-30}{2,-20}\n", "Number","Name","Sales");
        while (inputText != null) {
            string[] columns = new string [3];
            columns = inputText.Split(',');
            Console.WriteLine("{0,-15}{1,-30}{2,-10}\n", columns[0], columns[1], columns[2]);
            inputText = salesReport.ReadLine();
        }
    }
    static int safeToInt(string input, int defaultValue = 0){
        int result = 0;
        if(Int32.TryParse(input, out result)){
            return result;
        }
        return defaultValue;
    }
