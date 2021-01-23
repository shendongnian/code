    using System.Data;
    string numbers = "1 + 1, 2 - 1, 3 + 3";
    string[] equations = numbers.Split(',');
    DataTable dt = new DataTable();
    var values =equations.Select(x => dt.Compute(x, null));
    var output = string.Join(", ", values);
    Console.WriteLine(output);
