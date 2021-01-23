    public MvcHtmlString BaseModelHiddenFields()
    {
        StringBuilder outputString = new StringBuilder();
        if(CrDate != null && CrDate.HasValue)
        {
            sb.AppendFormat("<input type=\"hidden\" name\="CrDate\" value=\"{0}\">", CrDate.Value);
        }
        if(CrUser > 0)
        {
            sb.AppendFormat("<input type=\"hidden\" name\="CrUser\" value=\"{0}\">", CrUser);
        }
        if(MdDate != null && MdDate.HasValue)
        {
            sb.AppendFormat("<input type=\"hidden\" name\="MdDate\" value=\"{0}\">", MdDate.Value);
        }
        if(MdUser > 0)
        {
            sb.AppendFormat("<input type=\"hidden\" name\="MdUser\" value=\"{0}\">", MdUser);
        }
        return MvcHtmlString.Create(sb.ToString());
    }
