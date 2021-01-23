    public static class pageHelpers
    {
                public static System.Web.UI.Control FindControlRecursive(System.Web.UI.Control root, string id)
                {
                    if (root.ID == id)
                    {
                        return root;
                    }
                    foreach (System.Web.UI.Control c in root.Controls)
                    {
                        System.Web.UI.Control t = pageHelpers.FindControlRecursive(c, id);
                        if (t != null)
                        {
                            return t;
                        }
                    }
                    return null;
                }
    }
