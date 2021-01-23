     var temp = toCheck.GetData(DataFormats.FileDrop);
            string[] arr = ((IEnumerable)temp).Cast<object>().Select(x => x.ToString()).ToArray();
            string path = "";
            foreach(string a in arr)
                path = a;
