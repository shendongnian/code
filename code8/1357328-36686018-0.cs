    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("PreviousPage");
        CookieData cd = new CookieData();
        cd.IncidentLocation = txtIncloc.Text;
        cd.IncidentDay = ddlDay.SelectedValue;
        cd.IncidentMonth = ddlMonth.SelectedValue;
        cd.IncidentName = txtIncnam.Text;
        cd.IncidentType = txtInctype.Text;
        cd.StartTime = txtTimestart.Text;
        cd.Year = txtyear.Text;
        cookie.Value = ToXmlString(cd);
        Response.Cookies.Add(cookie);
    }
 
    public String ToXmlString(CookieData cdObj)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<List<string>>));
            StringWriter outSWriter = new StringWriter();
            xs.Serialize(outSWriter, cdObj);
            return outSWriter.ToString();
        }
