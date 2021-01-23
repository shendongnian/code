    if (null != boxFundingApproverPrinted)
    {
        if (String.IsNullOrEmpty(boxFundingApproverPrinted.Text))
        {
            spli["FundingApproverName"] = "[left blank]";
        }
        else
        {
            spli["FundingApproverName"] = boxFundingApproverPrinted.Text;
        }
    }
    else
    {
        spli["FundingApproverName"] = "[left blank]";
    }
