    String  word=Console.ReadLine()
    
    Console.Write("Enter the number of times to print \"word!\": ");
    int number = Integer.parse(Console.ReadLine());
    
    if(number>0){
       //loop number of  'number' times
       for(int i=0;i<number;i++){
    
           Console.WriteLine(word)
       }
    }
