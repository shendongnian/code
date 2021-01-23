        private class NoDupValueNameValueCollection : System.Collections.Specialized.NameValueCollection {
            public override void Add(string name, string value) {
                if (!(base.AllKeys.Contains(name)) || !(base.GetValues(name).Contains(value))) base.Add(name, value);
            }
        }
