    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       HiddenField hf =  e.Item.FindControl("HiddenField1") as HiddenField;
       if (hf != null)
       {
           string val = hf.Value;
           Image img = e.Item.FindControl("Image1") as Image;
           img.ImageUrl =  string.Format("data:image/jpg;base64,{0}",val);
       }
    }
