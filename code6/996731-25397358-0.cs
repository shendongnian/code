    //Add using System.Linq  statement at top.
    int[] numbers = new int[] { 1,2,3,4,5,6,7,8};
    foreach(var num in numbers.Skip(5))
    {
         Console.WriteLine(num);
    }
