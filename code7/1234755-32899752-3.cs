    public void MoveUp()
    {
        if (this.Parent == null)
            return;
        var index = this.Parent.Controls.GetChildIndex(this);
        if (index <= this.Parent.Controls.Count)
            this.Parent.Controls.SetChildIndex(this, index + 1);
    }
    public void MoveDown()
    {
        if (this.Parent == null)
            return;
        var index = this.Parent.Controls.GetChildIndex(this);
        if (index > 0)
            this.Parent.Controls.SetChildIndex(this, index - 1);
    }
