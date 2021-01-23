cs
public class Test
{
    public int[] Data { get; set; }
    public Test()
    {
        Data = new int[] { 0, 1, 2, 3, 4 };
    }
}
And a method to show how this can be saved:
cs
static void Main()
{
    using (var writer = new StreamWriter("db.csv"))
    using (var csv = new CsvWriter(writer))
    {
        var list = new List<Test>
        {
            new Test()
        };
        csv.Configuration.HasHeaderRecord = false;
        csv.WriteRecords(list);
        writer.Flush();
    }
}
The **important** configuration here is `csv.Configuration.HasHeaderRecord = false;`. Only with this configuration you will be able to see the data in the csv file.
Further details can be found in the related [unit test cases](https://github.com/JoshClose/CsvHelper/blob/2914f6856febbf7488c53ed65948a00a39f95a22/src/CsvHelper.Tests/TypeConversion/IEnumerableGenericConverterTests.cs#L215) from CsvHelper.
----------
In case you are looking for a solution to store properties of type `IEnumerable` with different amounts of elements, the following example might be of any help:
cs
using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace CsvHelperSpike
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var writer = new StreamWriter("db.csv"))
            using (var csv = new CsvWriter(writer))
            {
                csv.Configuration.Delimiter = ";";
                var list = new List<AnotherTest>
                {
                    new AnotherTest("Before String") { Tags = new List<string> { "One", "Two", "Three" }, After="After String" },
                    new AnotherTest("This is still before") {After="after again", Tags=new List<string>{ "Six", "seven","eight", "nine"} }
                };
                csv.Configuration.RegisterClassMap<TestIndexMap>();
                csv.WriteRecords(list);
                writer.Flush();
            }
            using(var reader = new StreamReader("db.csv"))
            using(var csv = new CsvReader(reader))
            {
                csv.Configuration.IncludePrivateMembers = true;
                csv.Configuration.RegisterClassMap<TestIndexMap>();
                var result = csv.GetRecords<AnotherTest>().ToList();
            }
        }
        private class AnotherTest
        {
            public string Before { get; private set; }
            public string After { get; set; }
            public List<string> Tags { get; set; }
            public AnotherTest() { }
            public AnotherTest(string before)
            {
                this.Before = before;
            }
        }
        private sealed class TestIndexMap : ClassMap<AnotherTest>
        {
            public TestIndexMap()
            {
                Map(m => m.Before).Index(0);
                Map(m => m.After).Index(1);
                Map(m => m.Tags).Index(2);
            }
        }
    }
}
By using the `ClassMap` it is possible to enable `HasHeaderRecord` (the default) again. It is important to note here, that this solution will only work, if the collection with different amounts of elements is the last property. Otherwise the collection needs to have a fixed amount of elements and the `ClassMap` needs to be adapted accordingly.
This example also shows how to handle properties with a `private set`. For this to work it is important to use the `csv.Configuration.IncludePrivateMembers = true;` configuration and have a default constructor on your class.
