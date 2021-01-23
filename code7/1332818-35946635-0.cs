    foreach (var c in this.Controls)
    {
        if(c is MaterialLabel)
        {
             var i = (MaterialLabel)c;
             i.Font = new Font(c.Font, FontStyle.Bold);
             i.ForeColor = Color.White;
        }
    }
...
    foreach (var c in this.Controls)
    {
        //slightly faster than the first version but won't work with struct
        var i = c as MaterialLabel; 
        if(i != null)
        {
             i.Font = new Font(c.Font, FontStyle.Bold);
             i.ForeColor = Color.White;
        }
    }
