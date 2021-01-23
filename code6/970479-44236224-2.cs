    #region"VCoupons"
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
           //dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));
            dr = dt.NewRow();
          //  dr["RowNumber"] = 1;
            dt.Rows.Add(dr);
            dt.TableName = "Coupons";
            //Store the DataTable in ViewState
            ViewState["dt_CouponData"] = dt;
            GridviewCoupon.DataSource = dt;
            GridviewCoupon.DataBind();
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;
            if (ViewState["dt_CouponData"] != null)
            {
                DataTable dt_CouponData = (DataTable)ViewState["dt_CouponData"];
                DataRow drCurrentRow = null;
                if (dt_CouponData.Rows.Count > 0)
                {
                    for (int i = 1; i <= dt_CouponData.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)GridviewCoupon.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridviewCoupon.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)GridviewCoupon.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)GridviewCoupon.Rows[rowIndex].Cells[4].FindControl("TextBox4");
                        drCurrentRow = dt_CouponData.NewRow();
                        //drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["Column1"] = box1.Text;
                        drCurrentRow["Column2"] = box2.Text;
                        drCurrentRow["Column3"] = box3.Text;
                        drCurrentRow["Column4"] = box4.Text;
                        rowIndex++;
                    }
                    //add new row to DataTable
                    dt_CouponData.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState
                    ViewState["dt_CouponData"] = dt_CouponData;
                    //Rebind the Grid with the current data
                    GridviewCoupon.DataSource = dt_CouponData;
                    GridviewCoupon.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            DataTable dt = (DataTable)ViewState["dt_CouponData"];
            //Set Previous Data on Postbacks
            int n = dt.Rows.Count;
            if (dt.Rows[0]["Column1"].ToString() == "" && dt.Rows[0]["Column2"].ToString() == "" && dt.Rows[0]["Column3"].ToString() == "" && dt.Rows[0]["Column4"].ToString() == "")
            {
                SetPreviousData();
            }
            else
            {
                SetData();
            }
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["dt_CouponData"] != null)
            {
                DataTable dt = (DataTable)ViewState["dt_CouponData"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)GridviewCoupon.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridviewCoupon.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)GridviewCoupon.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)GridviewCoupon.Rows[rowIndex].Cells[3].FindControl("TextBox4");
                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        box4.Text = dt.Rows[i]["Column4"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        private void SetData()
        {
            int rowIndex = 0;
            if (ViewState["dt_CouponData"] != null)
            {
                DataTable dt = (DataTable)ViewState["dt_CouponData"];
                int n = dt.Rows.Count;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (dt.Rows[j]["Column1"].ToString() == dt.Rows[j + 1]["Column1"].ToString() && dt.Rows[j]["Column2"].ToString() == dt.Rows[j + 1]["Column2"].ToString() && dt.Rows[j]["Column3"].ToString() == dt.Rows[j + 1]["Column3"].ToString() && dt.Rows[j]["Column4"].ToString() == dt.Rows[j + 1]["Column4"].ToString())
                        {
                            dt.Rows[j + 1]["Column1"] = "";
                            dt.Rows[j + 1]["Column2"] = "";
                            dt.Rows[j + 1]["Column3"] = "";
                            dt.Rows[j + 1]["Column4"] = "";
                        }
                    }
                }
                if (dt.Rows[n - 2]["Column1"].ToString() == "" && dt.Rows[n - 2]["Column2"].ToString() == "" && dt.Rows[n - 2]["Column3"].ToString() == "" && dt.Rows[n - 2]["Column4"].ToString() == "")
                {
                    dt.Rows[n - 2]["Column1"] = dt.Rows[n - 1]["Column1"];
                    dt.Rows[n - 2]["Column2"] = dt.Rows[n - 1]["Column2"];
                    dt.Rows[n - 2]["Column3"] = dt.Rows[n - 1]["Column3"];
                    dt.Rows[n - 2]["Column4"] = dt.Rows[n - 1]["Column4"];
                    dt.Rows[n - 1]["Column1"]="";
                    dt.Rows[n - 1]["Column2"]="";
                    dt.Rows[n - 1]["Column3"]="";
                    dt.Rows[n - 1]["Column4"]="";
                }
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        TextBox box1 = (TextBox)GridviewCoupon.Rows[i].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridviewCoupon.Rows[i].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)GridviewCoupon.Rows[i].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)GridviewCoupon.Rows[i].Cells[3].FindControl("TextBox4");
                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        box4.Text = dt.Rows[i]["Column4"].ToString();
                        rowIndex++;
                    }
                }
                int b = dt.Rows.Count;
                //Rebind the Grid with the current data
            }
        }
        private void SaveCoupons()
        {
            //int rowIndex = 0;
            if (ViewState["dt_CouponData"] != null)
            {
                DataTable dt_CouponData = (DataTable)ViewState["dt_CouponData"];
                DataRow drCurrentRow = null;
                if (dt_CouponData.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_CouponData.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)GridviewCoupon.Rows[i].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridviewCoupon.Rows[i].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)GridviewCoupon.Rows[i].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)GridviewCoupon.Rows[i].Cells[4].FindControl("TextBox4");
                        drCurrentRow = dt_CouponData.NewRow();
                       // drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["Column1"] = box1.Text;
                        drCurrentRow["Column2"] = box2.Text;
                        drCurrentRow["Column3"] = box3.Text;
                        drCurrentRow["Column4"] = box4.Text;
                        // rowIndex++;
                    }
                    dt_CouponData.Rows.Add(drCurrentRow);
                    //add new row to DataTable
                    //Store the current data to ViewState
                    ViewState["dt_CouponData"] = dt_CouponData;
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
        }
        private void Save()
        {
            int rowIndex = 0;
            if (ViewState["dt_CouponData"] != null)
            {
                DataTable dt_CouponData = (DataTable)ViewState["dt_CouponData"];
                DataRow drCurrentRow = null;
                if (dt_CouponData.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_CouponData.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)GridviewCoupon.Rows[i].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridviewCoupon.Rows[i].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)GridviewCoupon.Rows[i].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)GridviewCoupon.Rows[i].Cells[4].FindControl("TextBox4");
                        drCurrentRow = dt_CouponData.NewRow();
                        //drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["Column1"] = box1.Text;
                        drCurrentRow["Column2"] = box2.Text;
                        drCurrentRow["Column3"] = box3.Text;
                        drCurrentRow["Column4"] = box4.Text;
                        // rowIndex++;
                    }
                    //add new row to DataTable
                    dt_CouponData.Rows.Add(drCurrentRow);
                    int n = dt_CouponData.Rows.Count;
                    if (dt_CouponData.Rows[n - 2]["Column1"].ToString() == "" && dt_CouponData.Rows[n - 2]["Column2"].ToString() == "" && dt_CouponData.Rows[n - 2]["Column3"].ToString() == "" && dt_CouponData.Rows[n - 2]["Column4"].ToString() == "")
                    {
                        dt_CouponData.Rows[n - 2]["Column1"] = dt_CouponData.Rows[n - 1]["Column1"];
                        dt_CouponData.Rows[n - 2]["Column2"] = dt_CouponData.Rows[n - 1]["Column2"];
                        dt_CouponData.Rows[n - 2]["Column3"] = dt_CouponData.Rows[n - 1]["Column3"];
                        dt_CouponData.Rows[n - 2]["Column4"] = dt_CouponData.Rows[n - 1]["Column4"];
                        dt_CouponData.Rows[n - 1].Delete();
                       
                    }
                    int b = dt_CouponData.Rows.Count;
                    
                    int a = b - 1;
                    if (dt_CouponData.Rows[a]["Column1"].ToString() == dt_CouponData.Rows[a - 1]["Column1"].ToString() && dt_CouponData.Rows[a]["Column2"].ToString() == dt_CouponData.Rows[a - 1]["Column2"].ToString() && dt_CouponData.Rows[a]["Column3"].ToString() == dt_CouponData.Rows[a - 1]["Column3"].ToString() && dt_CouponData.Rows[a]["Column4"].ToString() == dt_CouponData.Rows[a - 1]["Column4"].ToString())
                    {
                        dt_CouponData.Rows[a].Delete();
                    }
                    //Store the current data to ViewState
                    ViewState["dt_CouponData"] = dt_CouponData;
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
        }
        private void SetPrevious()
        {
            int rowIndex = 0;
            if (ViewState["dt_CouponData"] != null)
            {
                DataTable dt = (DataTable)ViewState["dt_CouponData"];
                int o = 1;
                int b = dt.Rows.Count;
                int a = b - 1;
                GridviewCoupon.DataSource = dt;
                if (dt.Rows[0]["Column2"].ToString() == "")
                {
                    dt.Rows[0].Delete();
                }
             
                //else if (dt.Rows[a]["Column1"].ToString() == dt.Rows[a - 1]["Column1"].ToString() && dt.Rows[a]["Column2"].ToString() == dt.Rows[a - 1]["Column2"].ToString() && dt.Rows[a]["Column3"].ToString() == dt.Rows[a - 1]["Column3"].ToString() && dt.Rows[a]["Column4"].ToString() == dt.Rows[a - 1]["Column4"].ToString())
                //{
                //    dt.Rows[a].Delete();
                //}
                //if (dt.Rows[o]["Column1"].ToString() == dt.Rows[o - 1]["Column1"].ToString() && dt.Rows[o]["Column2"].ToString() == dt.Rows[o - 1]["Column2"].ToString() && dt.Rows[o]["Column3"].ToString() == dt.Rows[o - 1]["Column3"].ToString() && dt.Rows[o]["Column4"].ToString() == dt.Rows[o - 1]["Column4"].ToString())
                //{
                //    dt.Rows[0].Delete();
                //}
                GridviewCoupon.DataBind();
                if (dt.Rows.Count > 0)
                {
                    int j = dt.Rows.Count;
                    ViewState["dt_CouponData"] = dt;
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        TextBox box1 = (TextBox)GridviewCoupon.Rows[i].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridviewCoupon.Rows[i].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)GridviewCoupon.Rows[i].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)GridviewCoupon.Rows[i].Cells[4].FindControl("TextBox4");
                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        box4.Text = dt.Rows[i]["Column4"].ToString();
                        //if (rowIndex<dt.Rows.Count-1)
                        //{
                        //    rowIndex++;
                        //}
                    }
                }
            }
        }
        protected void GridviewCoupon_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "More")
            {
                objENT = new ENT();
                DataTable dt = (DataTable)ViewState["dt_CouponData"];
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                if (dt.Rows[0]["Column1"].ToString() == "" && dt.Rows[0]["Column2"].ToString() == "" && dt.Rows[0]["Column3"].ToString() == "" && dt.Rows[0]["Column4"].ToString() == "")
                {
                    index++;
                }
                Save();
                int count = dt.Rows.Count;
                if (count == index)
                {
                    dt.Rows[index - 1].Delete();
                }
                else
                {
                    dt.Rows[index].Delete();
                }
                ViewState["dt_CouponData"] = dt;
                SetPrevious();
            }
        }
        protected void GridviewCoupon_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button Delete = (Button)e.Row.FindControl("btnDelete");
                DataRowView dr = e.Row.DataItem as DataRowView;
                int index = e.Row.RowIndex;
                if (index == 0)
                {
                    Delete.Visible = false;
                }
                else
                {
                    Delete.Visible = true;
                }
            }
            
        }
        #endregion
    <div class="row" style="margin-top: 2%">
                            <div class="col-sm-1"></div>
                            <div class="container-fluid col-sm-10">
                                <asp:GridView ID="GridviewCoupon" OnRowEditing="GridviewCoupon_RowEditing" OnRowDataBound="GridviewCoupon_RowDataBound" OnRowCommand="GridviewCoupon_RowCommand" runat="server" Enabled="false" Style="text-align: center" ShowFooter="true" Width="99%"
                                    AutoGenerateColumns="false">
                                    <Columns>
                                        <%--<asp:BoundField DataField="RowNumber" HeaderText="Sr No" HeaderStyle-BackColor="#99CCCC" />--%>
                                        <%--   <asp:TemplateField HeaderText="Sr No" HeaderStyle-BackColor="#99CCCC">
                                            <ItemTemplate>
                                                <asp:Label ID="txtbox0" Text='<%# Bind("RowNumber")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <%--<asp:TemplateField HeaderText="Survey Number" HeaderStyle-BackColor="#99CCCC">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxS" CssClass="form-control" required="required" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Coupon Code" HeaderStyle-BackColor="#99CCCC">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox1" required="required" CssClass="form-control" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Coupon Description" HeaderStyle-BackColor="#99CCCC">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox2" MaxLength="250" required="required" CssClass="form-control" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Start Date" HeaderStyle-BackColor="#99CCCC">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox3"  required="required" placeholder="DD/MMM/YYYY" CssClass="form-control cal" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Date" HeaderStyle-BackColor="#99CCCC">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox4"  required="required" placeholder="DD/MM/YYYY" CssClass="form-control" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Date" HeaderStyle-BackColor="#99CCCC">
                                            <ItemTemplate>
                                                <asp:Button ID="btnDelete"  Text="Delete"
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    CommandName="More" CssClass="btn-primary btn"
                                                    Style="padding-top: 1%; padding-bottom: 1%; margin-top: 1px; margin-bottom: 1px" runat="server" />
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Right" />
                                            <FooterTemplate>
                                                <asp:Button ID="ButtonAdd" Font-Bold="true" runat="server" Text="Add New Row" CssClass="btn-toolbar btn" OnClick="ButtonAdd_Click" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <%--    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />--%>
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                                
                        </div>
                  
