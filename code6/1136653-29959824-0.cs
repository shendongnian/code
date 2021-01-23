     <asp:GridView ID="grvstdRes" runat="server" CssClass="table table-bordered table-hover" OnRowCommand="grvstdRes_RowCommand" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Document">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkstdres" runat="server" Text='<%#Eval("Alias") %>' 
    CommandArgument='<%#Eval("Idinstance") %>' CommandName="StudentResAliasName" ></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                   </asp:GridView>
       protected void grvstdRes_RowCommand(object sender, GridViewCommandEventArgs e)
        { 
            if(e.CommandName=="StudentResAliasName")
            {  
                using(objResultUnitBLL=new UnitBLL())
                {
                    using(objUnitDTO=new UnitDTO())
                    {
                        objUnitDTO = objResultUnitBLL.GetStudentResourceFile(Convert.ToInt64(e.CommandArgument));
                         string fileName=objUnitDTO.FileName; //to get the full path from DB
                         string[] pathArr = fileName.Split('\\'); // To split the path 
                         fileName = pathArr.Last().ToString(); //To get the file name  with extension
                         Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('../Upload/Instance/" + fileName + "','_newtab');", true); //to display the file in new window.
                    }
                }
            } 
        }
