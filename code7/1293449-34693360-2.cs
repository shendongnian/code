    using System.Text.RegularExpressions; 
    
    Console.WriteLine("Please Enter the Item Name");
    item1.itemname = Console.ReadLine();
    
    var containOnlyLetters = Regex.IsMatch(item1.itemname.Trim(), @"^[A-Za-z]+$");
