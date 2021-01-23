        public partial class Form1 : Form
    {
        VideoEntities vid = new VideoEntities();
        public Form1()
        {
            InitializeComponent();
            connectToMongo();
        }
        public void connectToMongo()
        {
            Utilitys util = new Utilitys();
            var con = "mongodb://127.0.0.1";
            MongoClient client = new MongoClient(con);
            var db = client.GetDatabase("Video");
            ObjectResult<getFrame_Result> frame;
            List<getFrame_Result> frameList;
            frame = vid.getFrame(50604803);
            frameList = frame.ToList();
            **var frameCollection = db.GetCollection<getFrame_Result>("Frame");**
            frameCollection.InsertOne(frameList[0]);
            Byte[] data = new Byte[0];
            var collection = db.GetCollection<BsonDocument>("Frame");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", 50604803);
            var result = collection.Find(filter).ToList();
            data = (Byte[]) result[0]["Frame"];
            MemoryStream mem = new MemoryStream(data);
            pictureBox.Image = Image.FromStream(mem);
        }
    }
