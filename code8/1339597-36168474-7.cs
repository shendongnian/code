    Public Function Permutate(Of T)(source As IEnumerable(Of T)) As IEnumerable(Of IEnumerable(Of T))
        Dim xs As T() = source.ToArray()
        Return If(xs.Length = 1,
                  {xs},
                  (From n In Enumerable.Range(0, xs.Length)
                   Let cs = xs.Skip(n).Take(1)
                   Let dss = Permutate(Of T)(xs.Take(n).Concat(xs.Skip(n + 1)))
                   From ds In dss Select cs.Concat(ds))
                  ).Distinct(New EnumerableEqualityComparer(Of T)())
    End Function
    Public Class EnumerableEqualityComparer(Of T) : Implements IEqualityComparer(Of IEnumerable(Of T))
    
        Public Shadows Function Equals(a As IEnumerable(Of T), b As IEnumerable(Of T)) As Boolean _
        Implements IEqualityComparer(Of IEnumerable(Of T)).Equals
            Return a.SequenceEqual(b)
        End Function
    
        Public Shadows Function GetHashCode(t As IEnumerable(Of T)) As Integer Implements _
        IEqualityComparer(Of IEnumerable(Of T)).GetHashCode
            Return t.Take(1).Aggregate(0, Function(a, x) a Xor x.GetHashCode())
        End Function
    
    End Class
