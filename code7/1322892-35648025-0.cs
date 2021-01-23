    try
    {
        var sty_in = Request.QueryString["style"].ToString();
        build.Append("test");
    }
    catch(Exception)
    {
        var tbl_st = (from c in db.tblfsk_style select c).ToArray();
        build.Append("<select id='style' name='style' class='styles'>");
        foreach (var style in tbl_st)
        {
            build.Append("<option value='" + style.StyleID + "'>" + style.Description + "</option>");
        }
        build.Append("</select>");
    }
