        var dict = new Dictionary<int, Tuple<double, double, double>>();
        nodeData_List = this.GetNodeInfo();
        nodeID_List = this.GetNodeIDInfo();
        nodeX_List = this.GetNodeXInfo();
        nodeY_List = this.GetNodeYInfo();
        nodeZ_List = this.GetNodeZInfo();
        for (int iNode = 0; iNode < nodeData_List.Count; iNode++)
        {
          dict.add(
            nodeID_List[iNode],
            new Tuple<double, double, double>(nodeX_List[iNode], nodeY_List[iNode], nodeZ_List[iNode]));
        }
