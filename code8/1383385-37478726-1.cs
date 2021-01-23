    protected void chkbxFileTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string eventTarget = Request.Form.Get("__EVENTTARGET");
            int index = Convert.ToInt32(eventTarget.Substring(eventTarget.Length-1));
            bool isUnchecked = !chkbxFileTypes.Items[index].Selected;
            if (isUnchecked)
            {
                string value = chkbxFileTypes.Items[index].Value;
            }
        }
