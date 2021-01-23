    public class FileDotEngine : IDotEngine
    {    
        public string Run(GraphvizImageType imageType, string dot, string outputFileName)
        {
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                writer.Write(dot);    
            }
            return System.IO.Path.GetFileName(outputFileName);
        }
    }
