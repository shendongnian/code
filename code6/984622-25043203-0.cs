    string serviceOptionTxt = "";
    for (int i = 0; i < chkServiceOption.Items.Count; i++)
    {
        if (chkServiceOption.Items[i].Selected)
            serviceOptionTxt += chkServiceOption.Items[i].Value + " ";
            // Or possibly?
            //serviceOptionTxt += chkServiceOption.Items[i].Text + " ";
        }
    }
    mailBody = mailBody.Replace("##ServiceType##", serviceOptionTxt);
