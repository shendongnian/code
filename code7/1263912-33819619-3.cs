    XmlDocument doc = new XmlDocument();
    doc.Load(Server.MapPath("~/xmlmail.xml"));
    var email = new XmlEmail();
    doc.IterateThroughAllNodes(
        delegate(XmlNode node)
        {
            if (node.Name.Equals("requestdate"))
                node.InnerText= email.RequestDate.ToLongDateString();
            if (node.Name.Equals("vehicle"))
            {
                XmlNodeList childs = node.ChildNodes;
                childs.IterateThrough(delegate(XmlNode vnode)
                {
                    if (vnode.Name.Equals("id"))
                        vnode.InnerText= email.VehicleId.ToString();
                    if (vnode.Name.Equals("year"))
                        vnode.InnerText= email.Year.ToString();
                    if (vnode.Name.Equals("make"))
                        vnode.InnerText= email.Make;
                    if (vnode.Name.Equals("model"))
                        vnode.InnerText= email.Model;
                    if (vnode.Name.Equals("vin"))
                        vnode.InnerText= email.Vin;
                    if (vnode.Name.Equals("trim"))
                        vnode.InnerText = email.Trim;
                });
            }
            if (node.Name.Equals("customer"))
            {
                XmlNodeList childs = node.ChildNodes;
                childs.IterateThrough(delegate(XmlNode vnode)
                {
                    if (vnode.Attributes != null && (vnode.Name.Equals("name") && vnode.Attributes["part"].Value.Equals("first")))
                        vnode.InnerText= email.FirstName;
                    if (vnode.Attributes != null && (vnode.Name.Equals("name") && vnode.Attributes["part"].Value.Equals("last")))
                        vnode.InnerText= email.LastName;
                    if (vnode.Name.Equals("email"))
                        vnode.InnerText= email.Email;
                    if (vnode.Name.Equals("phone"))
                        vnode.InnerText= email.Phone;
                    if (vnode.Name.Equals("comments"))
                        vnode.InnerText= email.Comments;
                    if (vnode.Name.Equals("address"))
                    {
                        XmlNodeList addresschilds = vnode.ChildNodes;
                        addresschilds.IterateThrough(delegate(XmlNode anode)
                        {
                            if (anode.Name.Equals("street"))
                                anode.InnerText= email.Street;
                            if (anode.Name.Equals("city"))
                                anode.InnerText= email.City;
                            if (anode.Name.Equals("phone"))
                                anode.InnerText= email.Phone;
                            if (anode.Name.Equals("regioncode"))
                                anode.InnerText= email.RegionCode;
                            if (anode.Name.Equals("postalcode"))
                                anode.InnerText= email.Postalode;
                            if (anode.Name.Equals("country"))
                                anode.InnerText= email.Country;
                        });
                    }
                });
            }
        });
