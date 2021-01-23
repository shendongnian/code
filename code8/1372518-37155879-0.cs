    using System;
    using System.IO;
    using System.Linq;
    public class Program
    {
        public const string INPUT_FILE_NAME = @"F:\Program12Dat.txt";
        public const string OUTPUT_FILE_NAME = @"F:\Output.txt";
    static void Main(string[] args)
    {
        var stuGradesArray = new double[7, 4];
        ReadData(stuGradesArray);
        DisplayAverages(stuGradesArray);
    }
    public static void ReadData(double[,] stuGradesArray)
    {
        try
        {
            StreamReader reader = new StreamReader(INPUT_FILE_NAME);
            using (reader)
            {
                int lineNumber = 0;
                // Read first line from the text file
                string line = reader.ReadLine();
                // Read the other lines from the text file
                while (line != null)
                {
                    double[] lineNumbers = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                               .Select(x => double.Parse(x))
                                               .ToArray();
                    for (int i = 0; i < lineNumbers.Length; i++)
                    {
                        stuGradesArray[lineNumber, i] = lineNumbers[i];
                    }
                    lineNumber++;
                    line = reader.ReadLine();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
    public static void DisplayAverages(double[,] stuGradesArray)
    {
        StreamWriter writer = new StreamWriter(OUTPUT_FILE_NAME);
        using (writer)
        {
            writer.WriteLine("Student #   Test1   Test2   Test3   Average");
            for (int i = 0; i < stuGradesArray.GetLength(0); i++)
            {
                var line = string.Empty;
                var average = 0d;
                for (int j = 0; j < stuGradesArray.GetLength(1); j++)
                {
                    line += stuGradesArray[i, j];
                    line += "\t";
                    if (j != 0)
                    {
                        average += stuGradesArray[i, j];
                    }
                }
                line += Math.Round(average / 3, 1);
                writer.WriteLine(line);
            }
        }
    }
}
