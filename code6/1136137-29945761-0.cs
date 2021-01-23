    Public Class RelativeRootImageProvider
        Implements iTextSharp.text.html.simpleparser.IImageProvider
    
        Public Property BasePath As String
    
        Public Sub New(basePath As String)
            Me.BasePath = basePath
        End Sub
    
        Public Function GetImage(src As String,
                                 attrs As IDictionary(Of String, String),
                                 chain As iTextSharp.text.html.simpleparser.ChainedProperties,
                                 doc As IDocListener) As iTextSharp.text.Image Implements iTextSharp.text.html.simpleparser.IImageProvider.GetImage
            ''//This should also check to see if src is absolute and maybe try getting it first before the below.
            ''//The below could also have a File.Exists() check, too.
            Dim newSrc = System.IO.Path.Combine(BasePath, src)
            Return iTextSharp.text.Image.GetInstance(newSrc)
        End Function
    End Class
