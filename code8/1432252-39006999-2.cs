    public int MyNumberMethod(object number) {
        return Convert.ToInt32(number);
    }
    public int GenericNumberMethod(int number) {
        return MyNumberMethod(number);
    }
    public int GenericNumberMethod(decimal number) {
        return MyNumberMethod(number);
    }
