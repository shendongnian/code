    public class MultiArrayList
    {
        private int i = 0;
        //private float[,] coordinates;
        public int MyProperty { get; set; }
        public float[] coordX { get; set; }
        public float[] coordY { get; set; }
        public float[] coordZ { get; set; }
        public float[] intensity { get; set; }
        //private Vector3 verts;
        // Use this for initialization
        public void Start()
        {
            string test = "1 2 3 99\n4 5 6 99\n7 89 90 99";
            string[] dataLines = test.Split('\n');
            string[] lineValues;
            //print (dataLines.Length);
            i = 0;
            //float[,] coordinates = new float[6853, 3]; 
            coordX = new float[4];
            coordY = new float[4];
            coordZ = new float[4];
            intensity = new float[4];
            foreach (string line in dataLines)
            {
                lineValues = line.Split(' ');
                float coordinateX = float.Parse(lineValues[0]);
                float coordinateY = float.Parse(lineValues[1]);
                float coordinateZ = float.Parse(lineValues[2]);
                float intens = float.Parse(lineValues[3]);
                coordX[i] = coordinateX;
                coordY[i] = coordinateY;
                coordZ[i] = coordinateZ;
                intensity[i] = intens;
                i++;
            }
            // save the entire class with the results.
            save("test.xml");
        }
        public void save(string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, this);
                writer.Flush();
            }
        }
        public static MultiArrayList Load(string FileName)
        {
            MultiArrayList t = new MultiArrayList();
            using (var stream = File.OpenRead(FileName))     
            {
                var serializer = new XmlSerializer(typeof(MultiArrayList));
                t = serializer.Deserialize(stream) as MultiArrayList;
            }
            
            return t;
        }
    }
