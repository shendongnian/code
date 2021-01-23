    public class MyTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; private set; }
    
        public MySerializable MySerValues { get; private set; }
    }
