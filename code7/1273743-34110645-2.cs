    public class PublicResult
    {
        public string Text { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set;}
    
        public override string ToString()
        {
            //return string.Format("{0}\n{1}\n{2}", Text, Name, ImagePath); <-- uncomment and delete other return if not using C# 6
            return $"{Text}\n{Name}\n{ImagePath}";
        }
    }
