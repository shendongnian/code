    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the name of the story file: ");
            string filename = Console.ReadLine();
            
           
            Asker ask = new Asker();
            string newSentence = ask.asker(filename);
            Console.WriteLine(newSentence);
            string name = Console.ReadLine();
        }
    }
    class Asker
    {
        public string asker(string sentence)
        {
            
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            string text = File.ReadAllText(sentence);
            text = text.Replace("<name>", name);
            
            File.WriteAllText(sentence, text);
            return text;
        }
    }
