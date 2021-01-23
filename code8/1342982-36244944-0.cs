            if (AdUser != null)
            {
                List<string> strList = new List<string>();
                var userProps = AdUser.Properties;
                foreach (var prop in userProps)
                {
                    string data = String.Format("property: {0} | value: {1}", prop.Name, prop.Value.ToString());
                    strList.Add(data);  
                }
                WriteObject(strList);
            }
