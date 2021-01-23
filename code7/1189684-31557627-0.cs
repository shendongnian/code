      namespace Hangman
       {
    class Program
        {
        static void Main(string[] args)
          {
            //StreamReader myWordList = new StreamReader("WordList.txt");//string stringArray[] = StreamReader(WordList.txt);//.WordList.txt;
            String[] myWordArrays = File.ReadAllLines("WordList.txt");
            Console.WriteLine(myWordArrays[2]);
            Console.ReadLine();
          }
        
        }
    }
