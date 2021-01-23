    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("flag") = 1 Then
                Session("flag") = 0
                Response.Write("<script>window.location.reload();</script>")
            End If
        Else
            Session("flag") = 1
        End If
    End Sub
    Protected Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Response.Redirect("Page3.aspx")
    End Sub
