csharp
// self referencing list in c#
// we cant use generic type syntax: new List<List<List..
// but dynamic keyword comes to save us
// and runtime is happy with that
var list = new List<dynamic>();
list.Add(list); // the "FBI! open up" part
Console.WriteLine(list[0][0][0][0][0][0][0].Count); // 1
