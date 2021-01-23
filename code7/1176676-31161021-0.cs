    string menu = OrganizeMenu(_nodes);
    private static string OrganizeMenu(List<Node> nodes)
    {
        menu.Append("<ul>"); // start the List
        List<Node> parentNode = nodes.Where(item => item.parentid == 0).ToList(); // Get all Parent Node (Root Node i.e. a Node with parentid = 0)
        List<Node> childNode = nodes.Except(parentNode).ToList(); // Get all Child Node (i.e. a Node with parentid != 0)
        foreach (var pNode in parentNode) // traverse for each Parent Node and add this to root level
        {
            menu.Append("<li>"); 
            menu.Append(pNode.name);
            GetChilds(nodes, pNode);
            menu.Append("</li>");
        }
        menu.Append("</ul>"); // end the list
            
        return menu.ToString();
    }
    private static void GetChilds(List<Node> nodes, Node parentNode)
    {
        List<Node> childs = nodes.Where(item=> item.parentid == parentNode.id).ToList();
        foreach (var child in childs)
        {
            menu.Append("<ul>");
            menu.Append(child.name);
            GetChilds(nodes, child);
            menu.Append("</ul>");
        }
    }
