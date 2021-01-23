    public static User get_user(IEnumerable<XElement> fields)
        {
            User u = new User();
            foreach (var item in fields)
            {
                String attribute = item.Attribute("name").Value;
                String val = item.Attribute("value").Value;
                if (attribute == "userName")
                {
                    u.UserName = val;
                }
                else if (attribute == "userStreet")
                {
                    u.UserStreet = val;
                }
                //and so on...
            }
            return u;
        }
