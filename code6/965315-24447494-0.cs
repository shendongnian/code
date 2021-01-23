    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        float? temp;
        if (!float.tryParse(e.Values[0], out temp))
        {
            //code to handle problems parsing here
            throw new InvalidCastException("Invalid cast: '{0}' cannot be parsed to a float", e.Values[0]);
        }
        var fP18VaR = temp.Value;
    }
