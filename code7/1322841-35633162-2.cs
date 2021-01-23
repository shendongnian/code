    var ds = new DataSet();
    ds.ReadXml("path to xml file");
    this.dataGridView1.DataSource = ds.Tables["Hotel"]; //Tables[0]
    this.dataGridView2.DataSource = ds.Tables["Hotel"]; //Tables[0]
    this.dataGridView2.DataMember = "Hotel_Room"; //ds.Tables[0].ChildRelations[0].RelationName;
