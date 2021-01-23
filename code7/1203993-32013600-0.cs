    var list = ctx.Web.Lists.GetByTitle(listTitle);
    var query = new CamlQuery();
    query.ViewXml = 
                           "<View>" +
                              "<RowLimit>1000</RowLimit>" +
                                  "<ViewFields>" +
                                      "<FieldRef Name='Title' />" +
                                     "<FieldRef Name='ProductName' />" +
                                     "<FieldRef Name='GroupName' />" +
                                   "</ViewFields>" +
                                   "<Query>" +
                                      "<Where>" +
                                          "<IsNotNull><FieldRef Name='GroupName' /></IsNotNull>" + 
                                      "</Where>" +
                                   "</Query>" +
                              "</View>";
    var items = list.GetItems(query);
    ctx.Load(items);
    ctx.ExecuteQuery();
