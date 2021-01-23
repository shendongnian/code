    Public Class Locat ' generated on http://jsonutils.com/
        Public Property status As String
        Public Property fromlatitude As Double
        Public Property fromlongitude As Double
        Public Property locationtype As String
        Public Property distancecoastmiles As Double
        Public Property closestdistancelatitude As Double
        Public Property closestdistancelongitude As Double
        Public Property elevationstart As Double
        Public Property elevationend As Integer
    End Class
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        'project reference to .Net System.Web.Extensions
        'Imports System.Web.Script.Serialization
        Dim jSerializer As New JavaScriptSerializer()
        Dim strData2 = <j>
            {
               "status":"OK",
               "fromlatitude":40.86791,
               "fromlongitude":-73.428906,
               "locationtype":"ROOFTOP",
               "distancecoastmiles":1.7,
               "closestdistancelatitude":40.8704815141,
               "closestdistancelongitude":-73.4612902712,
               "elevationstart":91.9,
               "elevationend":0
            }
            </j>.Value
        Try
            Dim o As Locat = jSerializer.Deserialize(Of Locat)(strData2)
            MsgBox(o.distancecoastmiles)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
