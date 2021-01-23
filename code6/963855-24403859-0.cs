    public class ParentNode
    {
        public ParentNode()
        {
            this.Child = new List<ChildNode>();
        }
        public string Parent { get; set; }
        public List<ChildNode> Child { get; set; }
    }
    
    public class ChildNode
    {
        public string Child { get; set; }
    }
    class DataTableTOJSON
    {   
        public static string GetJSON(DataTable dt)
        {            
            List<ParentNode> parent = new List<ParentNode>();            
    
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var innerRow = dt.Rows[i]["Parent"];
                var objParent = new ParentNode();
                bool alreadyExists = parent.Any(x => x.Parent.Contains(innerRow.ToString()));
    
                if (alreadyExists)
                    continue;
    
                DataRow[] foundRows = dt.Select("[Parent]='" + innerRow + "'");
    
                for (int k = 0; k < foundRows.Count(); k++)
                {
                    var objChild = new ChildNode();
                    objChild.Child = foundRows[k]["Child"].ToString();
                    objParent.Child.Add(objChild);
                }
    
                objParent.Parent = innerRow.ToString();
                parent.Add(objParent);
            }
            JavaScriptSerializer jsonString = new JavaScriptSerializer();
            return jsonString.Serialize(parent);
        }
    }
