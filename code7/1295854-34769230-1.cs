    // Building first value here
    foreach (ListItem cbitem in cblSecond.Items)
        {
            if (cbitem.Selected)
            {
                cblSecondValues += cbitem.Value + "-";
            }
        } 
    Response.Redirect("Results.aspx?cblvalues=" + cblvalues + "&cblSecondValues=" + cblSecondValues);
