      protected void ddlTrailerLoc_SelectedIndexChanged(object sender, EventArgs e)
            {
                DropDownList ddlTrailerLoc=sender as DropDownList;
    string value = "".
                if (!String.IsNullOrEmpty(ddlTrailerLoc.SelectedValue.ToString())
                {
                    value = ddlTrailerLoc.SelectedValue.ToString();
    
                    Trailer.UpdateTrailer(int.Parse(TrailerID), Company.Current.CompanyID,txtTrailerReg.Text,ddlTrailerLocation.Text);
                }
            }
