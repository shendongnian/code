       public List<string> BlockPalin(string s) {
            var list = new List<string>();
            for (int i = 1; i <= s.Length / 2; i++) {
                int backInx = s.Length - i;
                if (s.Substring(0, i) == s.Substring(backInx, i)) {
                    var result = string.Format("({0})", s.Substring(0, i));
                    result += "|" + result;
                    var rest = s.Substring(i, backInx - i);
                    if (rest == string.Empty) {
                        list.Add(result.Replace("|", rest));
                        return list;
                    }
                    else if (rest.Length == 1) {
                        list.Add(result.Replace("|", string.Format("({0})", rest)));
                        return list;
                    }
                    else {
                        list.Add(result.Replace("|", string.Format("({0})", rest)));
                        var recursiveList = BlockPalin(rest);
                        if (recursiveList.Count > 0) {
                            foreach (var recursiveResult in recursiveList) {
                                list.Add(result.Replace("|", recursiveResult));
                            }
                        }
                        else {
                        //EDIT: Thx to @juharr this list.Add is not needed...
                        //    list.Add(result.Replace("|",string.Format("({0})",rest)));
                            return list;
                        }
                    }
                }
            }
            return list;
        }
