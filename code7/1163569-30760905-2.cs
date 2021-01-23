        public TblBase FromXML (XmlNode itemNode)
    {
        foreach (XmlNode itemField in itemNode) {
            Type myType = this.GetType ();
            PropertyInfo myPropInfo = myType.GetProperty (itemField.Name);
            if (myPropInfo != null) {
                myPropInfo.SetValue (this, Convert.ChangeType (itemField.InnerText, myPropInfo.PropertyType), null);
            } else {            
                throw new MissingFieldException (string.Format ("[Fieldname]wrong fieldname: {0}", itemField.Name));
            }
        }
        return this;
    }
