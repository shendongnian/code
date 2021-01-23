    private Repeater updatePageWithDuties(List<ExperienceDuties> list)
    {
        Repeater rptDuties = new Repeater();
        rptDuties.DataSource = list;
        rptDuties.DataBind();
    
        foreach (RepeaterItem rptItem in rptDuties.Items)
        {
            if (rptItem.ItemIndex == 0)
            {
                var h4Tag = new HtmlGenericControl("h4");
                h4Tag.InnerHtml = "Duties";
                rptItem.Controls.Add(h4Tag);  <=====
            }
    
            var dutyLabel = new Label();
            ExperienceDuties expDuties = 
              ((IList<ExperienceDuties>) rptDuties.DataSource)[rptItem.ItemIndex];
            dutyLabel.Text = expDuties.Description;
            rptItem.Controls.Add(dutyLabel);   <=====
    
            var ltrHR = new LiteralControl();
            ltrHR.Text = "<hr />";
            rptItem.Controls.Add(ltrHR);  <=====
        }
    
        return rptDuties;
    }
