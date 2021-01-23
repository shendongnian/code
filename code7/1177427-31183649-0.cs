        public void inserta(int dat)
        {
            if (root == null)
            {
                root = new C_Nodo(dat);
            }
            else
            {
                this.root = insert_Order(this.root, dat);
            }
        }
        private C_Nodo insert_Order(C_Nodo tree, int inf)
        {
            if (tree == null)
            {
                tree = new C_Nodo(inf);
            }
            else
            {
                if (tree.DATO > inf)
                {
                    tree.LEFT = insert_Order(tree.LEFT, inf);
                }
                else
                {
                    tree.RIGHT = insert_Order(tree.RIGHT, inf);
                }
            }
            return tree;
        }
