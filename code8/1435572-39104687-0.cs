    public override bool Equals(object obj)
            {
                CategoryComponent cat = obj as CategoryComponent;
                if (cat != null)
                {
    //the right is this.Text == cat.Text
                    if (cat.Text == cat.Text)
                        return true;
                }
                return false;
            }
