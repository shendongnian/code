    public static class ExtentionsDictionary<T1,T2>{
        public static T2 Get(this IDictionary dict, MyEnum enum){
        var key = enum.ToString();
        return dict[key];
        }
        //Rest of the implementation
    }
