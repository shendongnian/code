    public class SampleFile<Toriginal> 
    {
        public SampleFile(string filename,string sname)
        {
             //Here you can use File as it is static
             var lines = File.ReadAllLines(filename);
        }
    }
