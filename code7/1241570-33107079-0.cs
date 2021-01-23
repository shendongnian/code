    public class MyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string OtherData { get; set; }
        public List<int> BlaBlaList { get; set; }
    
        public byte[] Serialize()
        {
            string json = JsonConvert.SerializeObject(this);
            return Encoding.ASCII.GetBytes(json);
        }
    
        public static string Deserialize(byte[] objectBytes)
        {
            return Encoding.ASCII.GetString(objectBytes);
        }
        public MyDBEntity ConvertToDBEntity()
        {
            MyDBEntity dbEntity = new MyDBEntity();
            dbEntity.ID = Id;
            dbEntity.Name = Name;
            dbEntity.SerializedData = this.Serialize();
            return dbEntity;
        }
    }
    
    public class MyDBEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] SerializedData { get; set; }
    }
