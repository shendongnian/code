    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
        public static class Program
        {
            private static void Main()
            {
                // Define your initial tree nodes.
                var tree = new List<TreeNode>
                {
                    new TreeNode
                    {
                        Id = 1,
                        ParentId = null,
                        Text = "Root Element 1"
                    },
                    new TreeNode
                    {
                        Id = 2,
                        ParentId = null,
                        Text = "Root Element 2"
                    },
                    new TreeNode
                    {
                        Id = 3,
                        ParentId = 1,
                        Text = "Child Element 1"
                    },
                    new TreeNode
                    {
                        Id = 4,
                        ParentId = 3,
                        Text = "Grandchild Element 1"
                    }
                };
    
                // Initialize serializer instance.
                var xmlSerializer = new XmlSerializer(tree.GetType());
    
                // Serialize your list. (Save into Xml File)
                using (var fileStream = File.OpenWrite("SerializerTest.xml"))
                {
                    xmlSerializer.Serialize(fileStream, tree);
                }
    
                // Deserialize your stored Xml file into a new tree object.
                using (var fileStream = File.OpenRead("SerializerTest.xml"))
                {
                    var loadedTree = xmlSerializer.Deserialize(fileStream) as List<TreeNode>;
                    if (loadedTree != null)
                    {
                        foreach (var node in loadedTree.Where(x => x.ParentId == null).ToList())
                        {
                            PrintNode(loadedTree, node);
                        }
                    }
                }
    
                Console.ReadLine();
            }
    
            private static void PrintNode(List<TreeNode> tree, TreeNode node)
            {
                Console.WriteLine("Id: {0} - Text: {1}", node.Id, node.Text);
                var children = tree.Where(x => x.ParentId == node.Id).ToList();
                foreach (var child in children)
                {
                    PrintNode(tree, child);
                }
            }
        }
    
        [Serializable]
        public class TreeNode
        {
            public int Id { get; set; }
            public int? ParentId { get; set; }
            public string Text { get; set; }
        }
    }
