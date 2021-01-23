    public override bool LoadPostData(string postDataKey, NameValueCollection postCollection) {
            var key = ClientID + InputHiddenPostfix;
            string text = this.Text;
            if (postCollection.AllKeys.Any(k => k.Equals(key))) {
                string item = postCollection[key];
                if (this.ReadOnly || text.Equals(item, StringComparison.Ordinal)) {
                    return false;
                }
                this.Text = item;
            } else {
                return false;
            }           
            return true;
        }
