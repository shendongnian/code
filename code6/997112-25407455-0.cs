        public string Get(XElement root, string path)
        {
            if (root== null)
                return null;
            string[] p = path.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            XElement at = root;
            foreach (string n in p)
            {
                at = at.Element(n);
                if (at == null)
                    return null;
            }
            return at.Value;
        }
