    Console.Write("Number: ");
    var num = int.Parse(Console.ReadLine());   // parse console input
    var range = Enumerable.Range(1, num);   //generate array of values from 1 to num
    var str = String.Concat(range.Select(x => x.ToString()));   //concatenate array of values
    Console.WriteLine(str);     // write string
    var sum = range.Sum(); // get sum of array
    Console.WriteLine("\nThe sum is: {0}", sum);   // write sum
    Console.ReadLine();   // pause
