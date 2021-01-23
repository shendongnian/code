    public class MyLi: ListItem
    {
        public DriveInfo DI { get; set;}
        public override string ToString()
        {
            return DI.ToString();
        }
    }
