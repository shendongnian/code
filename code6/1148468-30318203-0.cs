    class ElementTreeNode : TreeNode
    {    
      public ElementTreeNode()
      {
        ElementContextMenu = new ElementContextMenu();
      }
    
      public ElementContextMenu ElementContextMenu
      {
        get { 
          return ContextMenuStrip as ElementContextMenu; 
        }
        private set { 
          ContextMenuStrip = value; 
        }
      }
    }
