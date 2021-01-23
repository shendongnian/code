    public string seltest = null;
    string group1 = GroupsDBForm.gone;
    string[] tests1 =
                Directory.GetFiles("D:\\Riddler\\groups\\" + group1).Select(path => Path.GetFileName(path)).ToArray();
            foreach (string t1 in tests1)
            {
                test_list.Items.Add(group1+"\\"+t1);
            }
    private void begin_test_btn_Click(object sender, EventArgs e)
        {
            seltest = "D:\\Riddler\\groups\\" + test_list.Text;
            Do_Test_Form DoTest = new Do_Test_Form();
            DoTest.ShowPath = seltest;
            DoTest.MdiParent = this.ParentForm;
            DoTest.Show();
        }
