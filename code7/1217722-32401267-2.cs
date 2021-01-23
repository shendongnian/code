    public class Article {
        public string Name { get; set; }
        public string Colour { get; set; }
        public Article Rename(string newName) {
            return new Article {
                Name = newName
            //  Copy the remaining attributes
            ,   Colour = this.Colour
            };
        }
    }
