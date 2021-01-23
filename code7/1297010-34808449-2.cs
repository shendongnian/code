            string[,] Match_result = new string[list1.Count, 2];
            foreach (TreeNode node1 in nodes1)
            {
                for (int i = 0; i < actions1.Count; i++)
                {
                    TreeNode str1 = node1.Nodes[indx1].Nodes[i];
                    list1.Add(str1);
                    string TypeAction1 = actions1[i].Attributes["type"].Value;
                    string NameAction1 = actions1[i].Attributes["name"].Value;
                    Match_result[i, 0] = TypeAction1;
                    Match_result[i, 1] = NameAction1;
                }
            }
