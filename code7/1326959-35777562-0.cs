    DataSet ds = new DataSet();
    String MyXml = "<tasks><Task><Title>a</Title><Description>b</Description><Date>c</Date></Task><Task><Title>d</Title><Description>e</Description><Date>f</Date></Task></tasks>";
    StringReader sr = new StringReader(MyXml);
    ds.ReadXml(sr);
    gvData.DataSource = ds;
    gvData.DataBind();
