    if (item is string)
    {
        Response.Write(item + "<br/>");
    }
    else
    {
        foreach (var a in (object[])item)
        {
            Response.Write(a + "<br/>");
        }
    }
}
