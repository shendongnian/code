        protected void MyTree_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            for (int i = 0; i < e.Node.ChildNodes.Count; i++)
            {
                if (e.Node.ChildNodes[i].ChildNodes.Count != 0)
                    continue;
                string fileExt = Path.GetExtension(e.Node.ChildNodes[i].Text);
               
                if (fileExt == ".pdf")
                {
                    e.Node.ChildNodes[i].ImageUrl = "/Images/icons/pdf_icon.png";
                }
                else
                {
                    e.Node.ChildNodes[i].ImageUrl = "/Images/icons/document_icon.png";
                }
            }
        }
