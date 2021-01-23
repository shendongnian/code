struct s1
{
    byte _b1;
    byte _b2;
}
unsafe struct s2
{
    fixed s1 _s1[5]; // CS1663 here...
}
What I might consider if I decided I absolutely needed the structs to line up in a single contiguous block of data is something like this.
[StructLayout(LayoutKind.Explicit, Size = 2)]
struct s1
{   // Field offsets to emulate union style access which makes it
    // simple to get at the raw data in a primitive type format.
    [FieldOffset(0)]ushort _u1;
    [FieldOffset(0)]byte _b1;
    [FieldOffset(1)]byte _b2;
    public s1(ushort data)
    {
        _b1 = 0;
        _b2 = 0;
        _u1 = data;
    }
    public ushort ToUShort()
    {
        return _u1;
    }
}
unsafe struct s2
{
    public const int Size = 5;
    private fixed ushort _s1[Size];
    public s1 this[int index]
    {   // A public indexer that provides the data in a friendlier format.
        get
        {
            if (index < 0 || index >= Size )
                throw new IndexOutOfRangeException();
            return new s1(_s1[index]);
        }
        set
        {
            if (index < 0 || index >= Size)
                throw new IndexOutOfRangeException();
            _s1[index] = value.ToUShort();
        }
    }
}
If this looks like a hack, that's because it kinda is.  I wouldn't recommend this as a general solution because it's difficult to maintain but in those rare instances where you're working at this sort of low level and know in advance that the data spec won't be changing, then something like this technique can be viable.  But, even in those cases I'd still prefer to encapsulate as much of this low level stuff as is possible to minimize the chances of something going wrong.  That said, this *does* do exactly as asked which is for a workaround to having a fixed sized buffer of custom structs.
