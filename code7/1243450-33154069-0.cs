    public class Class1
    {
        public string xx { get { return this.xx } set { this.xx = value } }
    
        public void y()
        {
            string[] names = new string[3] {"A","B","C"};
            Random r = new Random();
            xx = (names[r.Next(0, 4)]);
        }
    }
