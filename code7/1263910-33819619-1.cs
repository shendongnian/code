    XmlDocument doc = new XmlDocument();
    doc.Load(Server.MapPath("~/xmlmail.xml"));
    var email = new XmlEmail();
    doc.IterateThroughAllNodes(
        delegate(XmlNode node)
        {
            if (node.Name.Equals("requestdate"))
                node.Value = email.RequestDate.ToLongDateString();
            if (node.Name.Equals("vehicle"))
            {
                XmlNodeList childs = node.ChildNodes;
                childs.IterateThrough(delegate(XmlNode vnode)
                {
                    if (vnode.Name.Equals("id"))
                        vnode.Value = email.VehicleId.ToString();
                    if (vnode.Name.Equals("year"))
                        vnode.Value = email.Year.ToString();
                    if (vnode.Name.Equals("make"))
                        vnode.Value = email.Make;
                    if (vnode.Name.Equals("model"))
                        vnode.Value = email.Model;
                    if (vnode.Name.Equals("vin"))
                        vnode.Value = email.Vin;
                    if (vnode.Name.Equals("trim"))
                        vnode.Value = email.Trim;
                });
            }
            if (node.Name.Equals("customer"))
            {
                XmlNodeList childs = node.ChildNodes;
                childs.IterateThrough(delegate(XmlNode vnode)
                {
                    if (vnode.Attributes != null && (vnode.Name.Equals("name") && vnode.Attributes["part"].Value.Equals("first")))
                        vnode.Value = email.FirstName;
                    if (vnode.Attributes != null && (vnode.Name.Equals("name") && vnode.Attributes["part"].Value.Equals("last")))
                        vnode.Value = email.LastName;
                    if (vnode.Name.Equals("email"))
                        vnode.Value = email.Email;
                    if (vnode.Name.Equals("phone"))
                        vnode.Value = email.Phone;
                    if (vnode.Name.Equals("comments"))
                        vnode.Value = email.Comments;
                    if (vnode.Name.Equals("address"))
                    {
                        XmlNodeList addresschilds = vnode.ChildNodes;
                        addresschilds.IterateThrough(delegate(XmlNode anode)
                        {
                            if (anode.Name.Equals("street"))
                                anode.Value = email.Street;
                            if (anode.Name.Equals("city"))
                                anode.Value = email.City;
                            if (anode.Name.Equals("phone"))
                                anode.Value = email.Phone;
                            if (anode.Name.Equals("regioncode"))
                                anode.Value = email.RegionCode;
                            if (anode.Name.Equals("postalcode"))
                                anode.Value = email.Postalode;
                            if (anode.Name.Equals("country"))
                                anode.Value = email.Country;
                        });
                    }
                });
            }
        });
