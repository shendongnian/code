    if (netscore >= Convert.ToDecimal(Session["top1"]))
    {
       if (netscore > Convert.ToDecimal(Session["top1"])) {
          Session["top3"] = Session["top2"];
          Session["top2"] = Session["top1"];
          Session["top1"] = netscore;
          Session["top1q"] = question.ToUpper();  
       }
       // If it's not a new top value, it will be ignored
    } 
    // ... and so on ...
