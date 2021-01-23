    static  void Main(string[] args)
           {
               string[,] names = {{"Deadpool", "Superman", "Spiderman"},{"Catwoman", "Batman", "Venom"}};
    
               for (int index0 = 0; index0 < names.GetLength(0); index0++)
               {
                   for (int index1 = 0; index1 < names.GetLength(1); index1++)
                   {
                       var name = names[index0, index1];
                       Console.Write(name);
                   }
               }
           }
