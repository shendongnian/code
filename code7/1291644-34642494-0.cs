    ''' <summary>
    '''     An XElement extension method that removes all namespaces described by @this.
    ''' </summary>
    ''' <param name="this">The @this to act on.</param>
    ''' <returns>An XElement.</returns>
    <System.Runtime.CompilerServices.Extension> _
    Public Function RemoveAllNamespaces(ByVal this As XElement) As XElement
    	Return New XElement(this.Name.LocalName, (
    		From n In this.Nodes()
    		Select (If(TypeOf n Is XElement, RemoveAllNamespaces(TryCast(n, XElement)), n))),If(this.HasAttributes, (
    			From a In this.Attributes()
    			Select a), Nothing))
    End Function
