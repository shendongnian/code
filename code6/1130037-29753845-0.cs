    <asp:GridView runat="server" id="GridView" AutoGenerateColumns="False" >
        <Columns>
                <asp:TemplateField>
                   <ItemTemplate>
                    <asp:Literal runat="server" id="ltDate" Text='<%#Bind("MyDate")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
    private void GridView_PreRender(object sender, System.EventArgs e)
        {
        string sCompareDate = "";
        foreach (GridViewRow gvRow in GridView.Rows) {
            //First Row
            if (string.IsNullOrEmpty(sCompareDate))
                sCompareDate = ((Literal)gvRow.FindControl("ltDate")).Text;
            if (sCompareDate != ((Literal)gvRow.FindControl("ltDate")).Text) {
                gvRow.Cells(0).Attributes.Add("style", "border-bottom-width:30px;");
                sCompareDate = ((Literal)gvRow.FindControl("ltDate")).Text;
        }
    }
    }
