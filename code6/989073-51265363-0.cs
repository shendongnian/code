    class GenericMethodHolder {
    	public void GenericMethod<T, U>(T obj, U parm1) {...};
    }
    public void AnotherMethod(string parm1, GenericMethodHolder holder)
    {
        holder.GenericMethod("test", 1);
        holder.GenericMethod(42, "hello world!");
        holder.GenericMethod(1.2345, "etc.");
    }
