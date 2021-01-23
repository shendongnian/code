        public static void Rename(Node the_node, string new_name)
        {
                List<Node> parent_list = new List<Node>();
                Node current_node = the_node;
                parent_list.Add(current_node);
                while (current_node.ParentNode != null)
                {
                    parent_list.Add(current_node.ParentNode);
                    current_node = the_node.ParentNode;
                }
                Rename(ref the_node, parent_list, new_name);
        }
        private static void Rename(ref Node target_node, List<Node> traverse_order, string new_name)
        {
            if (traverse_order.Count > 0)
            {
                Node current_node = traverse_order.Last();
                traverse_order.RemoveAt(traverse_order.Count - 1);
                int idx = Lists.IndexOf(current_node);
                EditNode(ref current_node, traverse_order);
            }
            else
            {
                target_node.Name = new_name;
            }
        }
