            List<Tuple<int, List<string>, List<string>>> List_type1 = new List<Tuple<int, List<string>, List<string>>>();
            foreach (TreeNode node1 in nodes1)
            {
                for (int i = 0; i < actions1.Count; i++)
                {
                    List_type1.Add(new Tuple<int, List<string>, List<string>>(i, new List<string>(), new List<string>()));
                    TreeNode str1 = node1.Nodes[indx1].Nodes[i];
                    list1.Add(str1);
                    string TypeAction1 = actions1[i].Attributes["type"].Value;
                    string NameAction1 = actions1[i].Attributes["name"].Value;
                    List_type1[i].Item2.Add(TypeAction1);
                    List_type1[i].Item3.Add(NameAction1);
                }
            }
