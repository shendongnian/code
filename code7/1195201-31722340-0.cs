            string someData = "";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("<ipaddress>", string.Empty);
            dic.Add("</ipaddress>", string.Empty);
            dic.Add(" ", Environment.NewLine);
            replacer(dic, someData);
