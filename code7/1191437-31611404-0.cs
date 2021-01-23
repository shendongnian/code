     public void setlist()
            {
                var allPeople = xmldoc.Descendants("grand").Select(n => new person
                                              {
                                                  name = n.Attribute("name").Value,
                                                  /*Sex = n.Attribute("sex").Value,   //never used
                                                  Status = n.Attribute("status").Value, //never used*/
                                                  child = n.Attribute("child").Value,
                                                  id = n.Attribute("id").Value,
                                                  father = n.Attribute("father").Value
                                              }).ToList();
    
                var rootTreeNode = GetTree(allPeople, "0").First();
                //do something with rootTreeNode....
            }
            private TreeNode[] GetTree(List<person> allPeople, string parent)
            {
                return allPeople.Where(p => p.father == parent).Select(p =>
                {
                    var node = new TreeNode(p.name);
                    node.Tag = p;
                    node.Nodes.AddRange(GetTree(allPeople, p.id));
                    return node;
                }).ToArray();
            }
