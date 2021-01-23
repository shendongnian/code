    public void RemoveChild(T child)
    {
                TreeNode<T> node = null;
                foreach (var childNode in _children)
                {
                    if (childNode.Item.Equals(child))
                    {
                        node = childNode;
                        break;
                    }
                }
                if (node != null)
                    _children.Remove(node);
    }
