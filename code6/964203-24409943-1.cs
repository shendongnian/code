    public static Variables Get( //added the 's' to Variable to make it work...
        this Microsoft.SqlServer.Dts.Runtime.Variables variables, string name) {
        foreach(Microsoft.SqlServer.Dts.Runtime.Variable item in variables) {
            if(item.Name == name) return item;
        }
        return null;
    }
