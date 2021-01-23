    private void LoadTreeView(DataTable dt)
        {
            var dNodes = new Dictionary<string, TreeNode>();
            foreach (DataRow dRow in dt.Rows)
            {
                string sSublang = dRow["Sub_lang"].ToString();
                string sCode = dRow["code"].ToString();
                string sName = dRow["name"].ToString();
                if (sSublang == "0")
                {
                    var tn = treeView1.Nodes.Add(sCode, sName);
                    dNodes.Add(sCode, tn);
                }
                else
                {
                    string[] arrSubLang = sSublang.Split('_');
                    for (int i = arrSubLang.Length - 1; i >= 0; i--)
                    {
                        string sFindCode = arrSubLang[i];
                        var tnLastParent = default(TreeNode);
                        if (dNodes.ContainsKey(sFindCode))
                        {
                            var tn = dNodes[sFindCode];
                            if (tnLastParent != default(TreeNode))
                            {
                                tn.Nodes.Add(tnLastParent);
                                tnLastParent = tn;
                            }
                            else if (!dNodes.ContainsKey(sCode))
                            {
                                tnLastParent = tn.Nodes.Add(sCode, sName);
                                dNodes.Add(sCode, tnLastParent);
                            }
                        }
                    }
                }
            }
            treeView1.ExpandAll();
        }
