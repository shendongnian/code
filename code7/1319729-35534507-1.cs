    public static List<string> GetObjectPropertiesPermutations(string src, string[] keys, int index) {
        if(index >= keys.Length) {
            return new List<string>() { src };
        }
        var list = new List<string>();
        var key = keys[index];
        foreach(var val in props[key]) {
            var other = GetObjectPropertiesPermutations(src + "/" + key + ":" + val, keys, index + 1);
            list.AddRange(other);
        }
        return list;
    }
    
    public static void Main(string[] args)
    {
        var perms = GetObjectPropertiesPermutations("", props.Keys.ToArray(), 0);
        foreach(var s in perms) {
            Console.WriteLine(s);
        }
    }
