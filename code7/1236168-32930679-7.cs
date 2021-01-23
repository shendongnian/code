     public string userGroup
        {
            get
            {
                if (ViewState["userGroup"] == null)
                    return "";
                return (ViewState["userGroup"].ToString());
            }
            set { ViewState["userGroup"] = value; }
        }
