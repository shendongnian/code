    [OracleCustomTypeMapping("<schema>.VARCHAR2MATRIX")]
    public class Varchar2Matrix : CustomCollectionTypeBase<Varchar2Matrix, Varchar2Row>
    {
    }
    
    [OracleCustomTypeMapping("<schema>.VARCHAR2ROW")]
    public class Varchar2Row : CustomCollectionTypeBase<Varchar2Row, string>
    {
    }
    
    public abstract class CustomCollectionTypeBase<TType, TValue> : CustomTypeBase<TType>, IOracleArrayTypeFactory where TType : CustomTypeBase<TType>, new()
    {
    	[OracleArrayMapping()]
    	public TValue[] Values;
    
    	public override void FromCustomObject(OracleConnection connection, IntPtr pointerUdt)
    	{
    		OracleUdt.SetValue(connection, pointerUdt, 0, Values);
    	}
    
    	public override void ToCustomObject(OracleConnection connection, IntPtr pointerUdt)
    	{
    		Values = (TValue[])OracleUdt.GetValue(connection, pointerUdt, 0);
    	}
    
    	public Array CreateArray(int elementCount)
    	{
    		return new TValue[elementCount];
    	}
    
    	public Array CreateStatusArray(int elementCount)
    	{
    		return new OracleUdtStatus[elementCount];
    	}
    }
    
    public abstract class CustomTypeBase<T> : IOracleCustomType, IOracleCustomTypeFactory, INullable where T : CustomTypeBase<T>, new()
    {
    	private bool _isNull;
    
    	public IOracleCustomType CreateObject()
    	{
    		return new T();
    	}
    
    	public abstract void FromCustomObject(OracleConnection connection, IntPtr pointerUdt);
    
    	public abstract void ToCustomObject(OracleConnection connection, IntPtr pointerUdt);
    
    	public bool IsNull
    	{
    		get { return this._isNull; }
    	}
    
    	public static T Null
    	{
    		get { return new T { _isNull = true }; }
    	}
    }
