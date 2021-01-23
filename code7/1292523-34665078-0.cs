    protected void Page_Load(object sender, EventArgs e)
            {
                if(!String.IsNullOrEmpty(Request.QueryString["srch"]))
                {
                    String srch = Request.QueryString["srch"];
                    if (!IsPostBack)
                    {
                        var myControl = (TextBox)Master.FindControl("search");
                        myControl.Text = srch;
                    }
                    
                    //perform search and display results
                    String connString = System.Configuration.ConfigurationManager.ConnectionStrings["GroupsConnString"].ToString();
    
                    conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
    
                    conn.Open();
                    queryStr = "";
                    queryStr = "SELECT g.*,CONCAT(firstname,' ',lastname) as name FROM app_groups.groups g LEFT JOIN users u ON u.id = g.id_user WHERE group_name LIKE '%" + srch + "%' OR group_type LIKE '%" + srch + "%'";
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
    
                    reader = cmd.ExecuteReader();
                    gname = "";//group name
                    gtype = "";//group type
                    uname = "";//user name
                    id = "";
                    warning = "";
                    id_owner = "";
    
                    if (reader.HasRows)
                    {
                        while (reader.HasRows && reader.Read())
                        {
                            uname = reader.GetString(reader.GetOrdinal("name"));
                            gname = reader.GetString(reader.GetOrdinal("group_name"));
                            gtype = reader.GetString(reader.GetOrdinal("group_type"));
                            id = reader.GetString(reader.GetOrdinal("id"));
                            id_owner = reader.GetString(reader.GetOrdinal("id_user"));
                            warning = reader.GetString(reader.GetOrdinal("warning"));
    
                            Panel pan = new Panel();
                            pan.CssClass = "col-sm-4";
                            Panel subpan = new Panel();
                            subpan.CssClass = "group";
    
                            if (Session["uid"] != null)
                            {
                                int sess_id = Convert.ToInt32(Session["uid"]);
    
                                if ((Session["uid"] != null && Session["uadmin"].Equals("1")) || sess_id.Equals(Int32.Parse(id_owner)))
                                {
                                    adminCtrls = new Panel();
                                    adminCtrls.CssClass = "adminCtrls";
                                    btn = new Button();//delete group button for admins and owners only
                                    btn.Click += new EventHandler(deleteGroup);
                                    btn.ID = "sterge";
                                    btn.CssClass = "btn btn-danger btn-xs";
                                    btn.Text = "Sterge grup";
                                    btn.CommandArgument = id;
                                    //btn.Attributes.Add("style", "float:right;");
                                    adminCtrls.Controls.Add(btn);
    
                                    if (Session["uadmin"].Equals("1"))
                                    {
                                        if (!warning.Equals("1"))
                                        {
                                            btn = new Button();//warn owner button for admins only
                                            btn.Click += new EventHandler(warnOwner);
                                            btn.ID = "warn";
                                            btn.CssClass = "btn btn-warning btn-xs";
                                            btn.Text = "Avertizeaza owner grup";
                                            btn.CommandArgument = id;
                                            adminCtrls.Controls.Add(btn);
                                        }
                                        else
                                        {
                                            btn = new Button();//warn owner button for admins only
                                            btn.ID = "warn";
                                            btn.Enabled = false;
                                            btn.CssClass = "btn btn-warning btn-xs";
                                            btn.Text = "A fost avertizat";
                                            adminCtrls.Controls.Add(btn);
                                        }
                                    }
                                }
                                else
                                {
                                    adminCtrls = null;
                                }
                                if (adminCtrls != null)
                                {
                                    subpan.Controls.Add(adminCtrls);
                                }
                            }
                            subpan.Controls.Add(new LiteralControl("<span class='title text-center'>" + gname + "</span><br/>"));
                            subpan.Controls.Add(new LiteralControl("<span>Owner: <span class='owner'>" + uname + "</span></span><br/>"));
                            subpan.Controls.Add(new LiteralControl("<span>Categorie: <span class='type'>" + gtype + "</span></span><br/>"));
                            pan.Controls.Add(subpan);
                            groupsShow.Controls.Add(pan);
                        }
                    }
    
                    reader.Close();
                    conn.Close();
                }
            }
