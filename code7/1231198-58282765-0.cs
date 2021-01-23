using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace EntityModelHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            // path to edmx file
            var filesPath = @"SamePath\Model.edmx";
            var lines = File.ReadAllLines(filesPath);
            var searchNames = new List<string>();
            foreach (var line in lines)
            {
                var searchString = "<EntitySetMapping Name=";
                if (line.Contains(searchString))
                {
                    var tmp = line.Substring(line.IndexOf(searchString) + searchString.Length+1);
                    var searchName = tmp.Substring(0, tmp.IndexOf("\""));
                    searchNames.Add(searchName);
                }
            }
            foreach (var duplicateName in searchNames.GroupBy(x => x).Where(x => x.Count() > 1))
            {
                Console.WriteLine(duplicateName.First());
            }
        }
    }
}
