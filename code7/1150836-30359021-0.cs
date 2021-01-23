    class Program{
      static void Main(string[] args){
        List<CreateItem> list  = new List<CreateItem>();
        CreateItem item = new CreateItem();
        item.name = "Necklace";
        item.value = 5;
        list.Add( item );
        Console.WriteLine(list[0].name); //This part of the code doesn't work. 
                                          //It can't find the property name. 
        Console.ReadLine();
      }
    }
