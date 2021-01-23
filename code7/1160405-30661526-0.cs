    <asp:GridView CssClass="table table-striped responsive" ID="GridView1" runat="server" AllowSorting="True" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="NoSurat" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnSorting="GridView1_Sorting"  onrowcommand="GridView1_RowCommand" PageSize="5">
                        <Columns>
                            <asp:TemplateField HeaderText="No Surat">
                                <ItemTemplate>
                                    <asp:Label ID="lblIDs" runat="server" Text='<%# Eval("NoSurat")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("NoSurat")%>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Perihal" HeaderText="Perihal" SortExpression="Perihal" />
                            <asp:BoundField DataField="AsalSurat" HeaderText="Asal Surat" SortExpression="AsalSurat" />
                            <asp:BoundField DataField="IsiSurat" HeaderText="Isi Surat" SortExpression="IsiSurat" />
                            <asp:BoundField DataField="tglsurat_terima" HeaderText="Tanggal Diterima" SortExpression="tglsurat_terima" />
                            <asp:BoundField DataField="tglsurat_kirim" HeaderText="Tanggal Dikirim" SortExpression="tglsurat_kirim" />
                            <asp:BoundField DataField="keterangan" HeaderText="Ket Surat" SortExpression="keterangan" />
                            <asp:BoundField DataField="namesScan" HeaderText="Nama File" SortExpression="namesScan" />                     
                            <asp:BoundField DataField="tglupload" HeaderText="Tanggal Upload Surat" SortExpression="tglupload" />
    
                            <asp:TemplateField HeaderText="Actions" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" CssClass="btn btn-danger glyphicon glyphicon-trash" OnClientClick="return confirm('Anda yakin untuk menghapus?'); "></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDownload" runat="server" Text="Download"   CommandName="Download" ></asp:LinkButton>  
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
    
    
     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
       {
            if (e.CommandName == "Download")
            {
                con1 = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            string fileid = Convert.ToString(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
            string name, type;
            using (SqlConnection con = new SqlConnection(con1))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select namesScan, contentType, DataSurat from SrtMasuk where NoSurat=@NoSurat";
                    cmd.Parameters.AddWithValue("@NoSurat", fileid);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Response.ContentType = dr["contentType"].ToString();
                        Response.AddHeader("Content-Disposition",
                                            "attachment;filename=\"" + dr["namesScan"] + "\"");
                        Response.BinaryWrite((byte[])dr["DataSurat"]);
                        Response.End();
                    }
                }
            }
            }
        }  
    </code>
