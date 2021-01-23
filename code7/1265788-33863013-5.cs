    private void DoFullCombine(StringBuilder sb)
    {
        this.Component1.DoSubCombine(sb);
        sb.Append("+");
        this.Component2.DoSubCombine(sb);
    }
    private void DoSubCombine(StringBuilder sb)
    {
        if (this.IsBaseGem)
        {
            sb.Append(this.ID);
        }
        else
        {
            sb.Append("(");
            this.DoFullCombine(sb);
            sb.Append(")");
        };
    }
