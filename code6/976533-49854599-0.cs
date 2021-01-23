    List<int> intList = new List<int> { 1, 3, 5, 7, 9, 13 };
    LinkedList<int> intLinkedList = new LinkedList<int>(intList);
    Console.WriteLine("Next Value to 9 "+intLinkedList.Find(9).Next.Value);
    Console.WriteLine("Next Value to 9 " +intLinkedList.Find(9).Previous.Value);
    //Consider using dictionary for frequent use
    var intDictionary = intLinkedList.ToDictionary(i => i, i => intLinkedList.Find(i));    
      
    Console.WriteLine("Next Value to 9 " + intDictionary[9].Next.Value);
    Console.WriteLine("Next Value to 9 " + intDictionary[9].Previous.Value);
    Console.Read();
