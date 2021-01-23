    public class Serializer{
    
        public void Seralize()
        {
            Properties prop = new Properties ();
            IFormatter f = new BinaryFormatter();
            Stream s = new FileStream("Properties/prop.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            f.Serialize(s, prop);
            s.Close();
        }
    
    }
