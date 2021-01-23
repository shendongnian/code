        public int GetHashCode(TagNode node)
        {
            int hash = node.Val.GetHashCode();
            foreach(TagNode child in node)
            {
               hash ^= child.GetHashCode();
            }
            return hash        
            
        }
