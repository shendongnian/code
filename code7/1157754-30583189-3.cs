    Partial Class Default2
        Inherits System.Web.UI.Page
    
        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            CType(Page.Master, MasterPage).Button.Text = "My Text"
        End Sub
    End Class
