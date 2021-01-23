    public bool Search(int item, TreeNode searchRoot){
        if (searchRoot != null) {
            if (item == searchRoot.GetItem ()) {
                return true;
            } else if (item < searchRoot.GetItem ()) {
                return Search (item, searchRoot.GetLeftNode ());
            } else if (item > searchRoot.GetItem ()) {
                return Search (item, searchRoot.GetRightNode ());
            }
        } else {
            return false;
        }
    }
