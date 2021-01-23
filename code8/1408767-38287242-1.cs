    class Bag
    {
        public string Name = string.Empty;
        public int Size = 0;
        public List<int?> Counts = new List<int?>();
        public List<int?> IDs = new List<int?>();
        public List<string> Links = new List<string>();
        
        public Bag() { }
        public static Bag Parse(string input)
        {
            Bag bag = new Bag();
            int? iv = null;
            int idx = input.IndexOf("[\"") + 2;
            bag.Name = input.Substring(idx, input.IndexOf("\"]") - idx);
            idx = input.IndexOf("[\"size\"] = ") + "[\"size\"] = ".Length; // len;
            bag.Size = int.Parse(input.Substring(idx, input.Substring(idx).IndexOf(",")));
            foreach (object val in GetVals("ids", input, bag.Size)) {
                iv = null;
                if (val != null && val.ToString() != "nil") {
                    iv = int.Parse(val.ToString());
                }
                bag.IDs.Add(iv);
            }
            foreach (object val in GetVals("links", input, bag.Size)) {
                bag.Links.Add((string)val);
            }
            foreach (object val in GetVals("counts", input, bag.Size)) {
                iv = null;
                if (val != null && val.ToString() != "nil") {
                    iv = int.Parse(val.ToString());
                }
                bag.Counts.Add(iv);
            }
            return bag;
        }
        private static List<object> GetVals(string id, string input, int size)
        {
            List<object> list = new List<object>();
            for (int i = 0; i < size; ++i) { list.Add(null); }
            string tmp, ival = string.Format("[\"{0}\"] = {{", id);
            string[] tsplit = null;
            int len = ival.Length;
            int idx = input.IndexOf(ival) + len;
            foreach (string val in input.Substring(idx, input.Substring(idx).IndexOf("}")).Split('\n')) {
                tmp = val.Trim();
                if (string.IsNullOrEmpty(tmp)) { continue; }
                tsplit = tmp.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (tsplit.Length == 2) {
                    int i = (int.Parse((((tsplit[1].Replace("-", "")).Replace("[", "")).Replace("]", "")).Trim()) - 1);
                    list[i] = tsplit[0].Trim();
                } else {
                    int i = (int.Parse((tsplit[0].Substring(0, tsplit[0].IndexOf("=")).Replace("[", "")).Replace("]", "").Trim()) - 1);
                    list[i] = tsplit[0].Substring(tsplit[0].IndexOf("=") + 1).Trim();
                }
            }
            return list;
        }
    }
    
