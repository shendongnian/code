    <Serializable>
    Friend Class CtlItem
        Public Property Location As Point
        Public Property Size As Size
        Public Property BackColor As Color
        Public Property Text As String
    
        ' some serializers require a simple ctor
        Public Sub New()
    
        End Sub
        ' create object from passed PB
        Public Sub New(pb As Button)
            Location = pb.Location
            Size = pb.Size
            BackColor = pb.BackColor
            Text = pb.Text
        End Sub
    End Class
