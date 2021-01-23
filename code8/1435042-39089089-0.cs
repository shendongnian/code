    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ProgrammingBasics
    {
        class Program
        {
            static void Main(string[] args)
            {
                TreeModel model = new TreeModel();
                string text = model.ShowTree();
                Console.WriteLine(text);
                Console.ReadLine();
            }
        }
        public class TreeModel
        {
            public int Id { get; set; }
            public int? ParentId { get; set; }
            public string Name { get; set; }
            public static List<TreeModel> GetData()
            {
                var list = new List<TreeModel>()
                {
                    new TreeModel() {Id = 1,ParentId = null,Name = "Name1"},
                    new TreeModel() {Id = 2,ParentId = null,Name = "Name2"},
                    new TreeModel() {Id = 3,ParentId = null,Name = "Name3"},
                    new TreeModel() {Id = 4,ParentId = 1,Name = "Name4"},
                    new TreeModel() {Id = 5,ParentId = 1,Name = "Name5"},
                    new TreeModel() {Id = 6,ParentId = 4,Name = "Name6"},
                    new TreeModel() {Id = 7,ParentId = 6,Name = "Name7"},
                };
                return list;
            }
            public string ShowTree()
            {
                int level = 0;
                return ShowTreeRecursive(GetData(), level, null); 
            }
            public static string ShowTreeRecursive(List<TreeModel> source, int level, int? ParentId)
            {
                string text = "";
                foreach(var node in source.Where(x => x.ParentId == ParentId))
                {
                    text += string.Format("{0} {1}\n", new string(' ', 3 * level), node.Name);
                    text += ShowTreeRecursive(source, level + 1, node.Id);
                }
                return text;
            }
        }
    }
