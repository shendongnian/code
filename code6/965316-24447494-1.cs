    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        float? temp;
        if (!float.TryParse(e.Values[0], out temp))
        {
            //code to handle problems parsing here
            throw new InvalidCastException("Invalid cast: '{0}' cannot be parsed to a float", e.Values[0]);
        }
        //if we reach here (we've not thrown an error above), `temp` is not null
        var fP18VaR = temp.Value;
    }
