    public virtual string Render()
    {
        response.Write("<p>");
        if (CONDITION)
            response.Write("<span>TRUE</span>");
        else
            response.Write("<span>FALSE</span>");
        response.Write("</p>");
    }
