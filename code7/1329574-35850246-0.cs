    public static class MyClass {
        public static string AndHisNameIs;
    }
    public void SomewhereInTheCode() {
        ....
        MyClass.AndHisNameIs = "JOHN CEENA";
        ....
    }
    [WebMethod]
    public static string SetFileNameU(List<string> someValues)
    {
        string journey = Convert.ToString(someValues[0]);
        return MyClass.AndHisNameIs;
    }
