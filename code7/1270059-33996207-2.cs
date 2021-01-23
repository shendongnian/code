    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace JsonTreeView
    {
        public class DataNode
        {
            public string Text { get; set; }
            public bool IsChecked { get; set; }
            public List<DataNode> Children { get; set; }
        }
    
        public static class TreeRepository
        {
    
            public static List<DataNode> LoadDataNodes(string jsonFilePath)
            {
                var json = System.IO.File.ReadAllText(jsonFilePath);
                var dataNodes = JsonConvert.DeserializeObject<List<DataNode>>(json);
                return dataNodes;
            }
    
            public static void Load(this TreeView treeView, string jsonFilePath)
            {
                treeView.Nodes.Load(LoadDataNodes(jsonFilePath));
            }
    
            public static void Load(this TreeNodeCollection nodes, List<DataNode> dataNodes)
            {
                foreach(var dataNode in dataNodes)
                {
                    var treeNode = nodes.Add(dataNode.Text);
                    treeNode.Checked = dataNode.IsChecked;
                    if (dataNode.Children != null && dataNode.Children.Count > 0)
                    {
                        Load(treeNode.Nodes, dataNode.Children);
                    }
                }
            }
    
            public static List<DataNode> GetDataNodes(this TreeView treeView)
            {
                var dataNodes = new List<DataNode>();
                AddNodesToList(treeView.Nodes, dataNodes);
                return dataNodes;
            }
    
            private static void AddNodesToList(TreeNodeCollection nodes, List<DataNode> dataNodes)
            {
                foreach (TreeNode node in nodes)
                {
                    var dataNode = new DataNode
                    {
                        Children = new List<DataNode>(),
                        IsChecked = node.Checked,
                        Text = node.Text
                    };
                    dataNodes.Add(dataNode);
                    if (node.Nodes.Count > 0)
                    {
                        AddNodesToList(node.Nodes, dataNode.Children);
                    }
                }
            }
    
            public static void Save(this TreeView treeView, string jsonFilePath)
            {
                var dataNodes = treeView.GetDataNodes();
                var json = JsonConvert.SerializeObject(dataNodes, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, json);
            }
        }
    }
