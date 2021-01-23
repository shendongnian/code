     public static Control GetParentControl(this Control c, Type type)
            {
                Control p = c.Parent;
                while (p != null && !(p.GetType().IsSubclassOf(type)))
                {
                    p = p.Parent; 
                }
    
                return p; 
            }
