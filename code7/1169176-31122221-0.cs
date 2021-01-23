       private void RemoveEmpty(HtmlNode node){
           var parent = node.Parent;
           node.Remove();
           if(parent==null)
               return;
           // remove parent if it is empty
           if(!parent.DescendantNodes.Any()){
               RemoveEmpty(parent);
           }
       }
        
    private void Truncate(DocumentNode root, int maxLimit){
    
        var n = 0;
        HtmlTextNode lastNode = null;
        
        foreach(var node in root.DescendantNodes
             .OfType<HtmlTextNode>().ToArray()){
           var length = node.Text.Length;
        
           if(n + length >= maxLimit){
                RemoveEmpty(node);
                continue;
           }
           lastNode = node;
           n+= length;
        
        }
    }
    // you are left with only nodes that add up to your max limit characters.
