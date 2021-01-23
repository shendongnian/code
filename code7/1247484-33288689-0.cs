    public static Dictionary<string, object> FilterAPIData(string data)
        {
            var r = new Regex(@"\[\w+\], \'[\w/]+\'");
            var result = r.Matches(data);
            var dict = new Dictionary<string, object>();
            foreach (Match item in result)
            {
                var val = item.Value.Split(',');
                dict.Add(val[0], val[1]);
            }
            return dict;
        }
