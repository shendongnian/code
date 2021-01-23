    public void showDialog_Event(object sender, EventArgs e) {
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalDialog').modal({'backdrop': 'static', 'keyboard': 'static', 'show': true});");
            sb.Append("$('#modalBodyDialog').html('<ul><li>");
            sb.Append(message);
            sb.Append("</li></ul>')");
            sb.Append(@"</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ModalScript", sb.ToString(), false);
    }
