    try
            {
                XmlReader xmlFile;
                xmlFile = XmlReader.Create("E:\\Product.xml", new XmlReaderSettings());
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                var TblTitle = ds.Tables[0];
                var i = 39;
                var j = 67;
                foreach(DataRow row in TblTitle.Rows)
                {
                    //Create new GroupBox
                    GroupBox GrpBox = new GroupBox();
                    GrpBox.Text = row.ItemArray[1].ToString();
                    GrpBox.Location = new System.Drawing.Point(i, j);
                    //Create new Checkboxlist in GroupBox
                    CheckedListBox ChkList = new CheckedListBox();
                    ChkList.Location = new System.Drawing.Point(44, 20);
                    ChkList.DataSource = TblTitle.ChildRelations[0].ChildTable;
                    ((ListBox)ChkList).ValueMember = "Name";
                    ((ListBox)ChkList).DisplayMember = "Name";
                    //add Checkboxlist into GroupBox
                    GrpBox.Controls.Add(ChkList);
                    //add this groupBox to Form
                    this.Controls.Add(GrpBox);
                    
                    //set position for next one
                    i = +1;
                    j = +176;
                }
               
               
                //checkedListBox1.
                //checkedListBox1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
