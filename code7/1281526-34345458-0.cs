    Type clrType = SqlDbTypeResolver.GetClrType(cmd.Parameters[index].DbType);
    try
    { 
        Convert.ChangeType(parm.Value, clrType); // no need to store the value, I just need to catch the exception if thrown.
    }
    catch(SomeException ex)
    {
        //report stuff to user about failed conversion
    }
