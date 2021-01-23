    >>> sc=System.Net.Http.StringContent("abcdefghijklmnopqrstuvwxyz")
    #in C#, the following is `type(StringContent)' (this is what it actually does)
    >>> scd=System.Reflection.TypeDelegator(System.Net.Http.StringContent)
    >>> print scd.GetField("content",System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Instance)
    None     #because the field is in ByteArrayContent and is private
    >>> bacd=System.Reflection.TypeDelegator(System.Net.Http.ByteArrayContent)
    >>> bacd.GetField("content",System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Instance)
    <System.Reflection.RtFieldInfo object at 0x000000000000002C [Byte[] content]>
    # `_' is last result
    >>> _.GetValue(sc)
    Array[Byte]((<System.Byte object at 0x000000000000002D [97]>, <System.Byte objec
    t at 0x000000000000002E [98]>, <System.Byte object at 0x000000000000002F [99]>,
    <...>
