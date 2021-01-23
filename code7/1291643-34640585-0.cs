    <System.Runtime.CompilerServices.Extension()> _
    Public Function RemoveAllNamespaces(this As XElement) As XElement
        Return New XElement(this.Name.LocalName,
            (From n In this.Nodes
             Select (If(TypeOf n Is XElement, TryCast(n, XElement).RemoveAllNamespaces(), n))),
            If((this.HasAttributes), (From a In this.Attributes Select a), Nothing))
    End Function
