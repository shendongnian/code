    private TreeNode GenerateDataModel(TreeNode TrvNode, int PositionIndex) {
            foreach (var grpData in ApplicationManager.GetGroupingInfo().Where(x => x.PositionIndex == PositionIndex)) {
                string sectionQuery = Query + " Select Distinct(" + grpData.Fieldname + ") from DataTbl" +
                    (TrvNode == null ? string.Empty : " where " + TrvNode.Tag.ToString()) +
                    " order by " + grpData.Fieldname + " " + (grpData.OrderBy == GroupOrder.Descending ? "Desc" : string.Empty);
                appMgr.ExecuteQuery(sectionQuery);
                DataSet dSet = new DataSet();
                appMgr.GetData(ref dSet);
                foreach (DataRow dtRow in dSet.Tables[0].Rows) {
                    string con = string.Empty;
                    if (TrvNode != null)
                        con = TrvNode.Tag.ToString() + " And ";
                    TreeNode trvNode = new TreeNode() {
                        Text = dtRow[grpData.Fieldname].ToString(),
                        Tag = con + grpData.Fieldname + "='" + dtRow[grpData.Fieldname].ToString() + "'"
                    };
                    TreeNode retTreeNode = GenerateDataModel(trvNode, PositionIndex + 1);
                    if (TrvNode == null)
                        trvGroupDataModel.Nodes.Add(trvNode);
                    else {
                        TrvNode.Nodes.Add(trvNode);
                    }
                }
            }
            return TrvNode;
        }
