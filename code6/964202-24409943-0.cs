    public static Variable Get(
        this Microsoft.SqlServer.Dts.Runtime.Variables variables, string name) {
        foreach(Microsoft.SqlServer.Dts.Runtime.Variable item in variables) {
            if(item.Name == name) return item;
        }
        return null;
    }
