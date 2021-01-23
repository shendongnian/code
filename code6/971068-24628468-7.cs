    public class A
    {
        public A(string property0, string property1, string property2)
        {
            Property0 = property0;
            Property1 = property1;
            Property2 = property2;
    
            SubNodes = new List<A>();
        }
    
        public string Property0 { get; set; }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    
        public List<A> SubNodes { get; private set; }
    }
    public class TreeDataSource : List<A>, TreeList.IVirtualTreeListData
    {
        void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            var a = info.Node as A;
    
            info.Children = a.SubNodes;
        }
    
        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var a = info.Node as A;
    
            switch (info.Column.FieldName)
            {
                case "Property0":
                    info.CellData = a.Property0;
                    break;
                case "Property1":
                    info.CellData = a.Property1;
                    break;
                case "Property2":
                    info.CellData = a.Property2;
                    break;
            }
        }
    
        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            var a = info.Node as A;
    
            switch (info.Column.FieldName)
            {
                case "Property0":
                    a.Property0 = (string)info.NewCellData;
                    break;
                case "Property1":
                    a.Property1 = (string)info.NewCellData;
                    break;
                case "Property2":
                    a.Property2 = (string)info.NewCellData;
                    break;
            }
        }
    }
