    Imports Microsoft.Office.Interop
    
    Public Class MsProjectMethods
    
        Public Function MsProjectDateDifference(ByVal ProjApp As MSProject.Application,
                                                ByVal startDate As DateTime,
                                                ByVal finishDate As DateTime) As Int32
            Dim returnValue As Object = ProjApp.DateDifference(startDate, finishDate)
            If IsNumeric(returnValue) Then
                Return Convert.ToInt32(returnValue)
            Else
                Throw New System.Exception("An exception has occurred.")
            End If
        End Function
    
    End Class
