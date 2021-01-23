      class FormAction
    {
     DBConnection dbCon = new DBConnection();
     public bool txtBoxValidate(Control txtBoxName, string msg, Control frmName)
        {
            if (String.IsNullOrEmpty(txtBoxName))
            {
                MessageBox.Show(msg, MsgBoxStyle.Exclamation, frmName.Text);
                txtBoxName.Focus();
                 return false;
            }
            else
            {
             return true;
            }
         }
    public void ValChkDubANDexe(string sqlSTR_Chk, string sqlSTR_exe, Control frmName)
        {
            dbCon.ExecuteSQLQuery(sqlSTR_Chk);
        if (dbCon.sqlDT.Rows.Count > 0)
        {
           MessageBox.Show("Item Already Exist in Database", frmName.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }
        dbCon.ExecuteSQLQuery(sqlSTR_exe);
        MessageBox.Show("Data Has Been Saved.", frmName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    } 
     FormReset frmReset = new FormReset();
     FormAction frmAct = new FormAction();
     private void btnSave_Click(object sender, EventArgs e)
        {
    string sqlSTR_Chk;
    string sqlSTR_exe;
    bool HasText = frmAct.txtBoxValidate(TextBox1, "Please Enter The Age.", this);
    if(HasText)
    {
    sqlSTR_Chk = "SELECT * FROM Table1 WHERE Field1 = '" + TextBox1 .Text + "'"; //Dublicate Check
    sqlSTR_exe = "INSERT INTO Table1(Field1) VALUES('" + TextBox1 .Text + "')";
    frmAct.ValChkDubANDexe(sqlSTR_Chk, sqlSTR_exe, this);
    }
    frmReset.ResetAllControls(this);
    }
