      using System;
      using System.Collections.Generic;
      using System.ComponentModel;
      using System.Data;
      using System.Drawing;
      using System.Text;
      using System.Windows.Forms;
      using System.Data.SqlClient;
      using System.IO;
    namespace sqlFileExample
    {
      public partial class frmMain : Form
    {
        SqlConnection objConn = new SqlConnection();
        string strSqlConn = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\honesty\Downloads\sqlFileExample\sample db\db2.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        string strQuery_AllAttachments = "select [id], [fileName], [fileSize] from [tblAttachments] order by [fileName]";
        string strQuery_GetAttachmentById = "select * from [tblAttachments] where [id] = @attachId";
        string strQuery_AllAttachments_AllFields = "select * from [tblAttachments]";
        public frmMain()
        {
            InitializeComponent();
            //prevent resize at runtime
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; 
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "SQL file upload/download example";
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            objConn.ConnectionString = strSqlConn; //set connection params
            FillDataGrid(gridViewMain, strQuery_AllAttachments);
        }
        private void ConnectToDb()
        {
            //objConn.ConnectionString = strSqlConn; //set our connection params
            //objConn.Open(); //open connection
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //objConn.Close();  //close connection
        }
        private void FillDataGrid(DataGridView objGrid, string strQuery)
        {
            DataTable tbl1 = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = objConn;  // use connection object
            cmd1.CommandText = strQuery; // set query to use
            adapter1.MissingSchemaAction = MissingSchemaAction.AddWithKey;  //grab schema
            adapter1.SelectCommand = cmd1; //
            adapter1.Fill(tbl1);  // fill the data table as specified
            objGrid.DataSource = tbl1;  // set the grid to display data
        }
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (ofdMain.ShowDialog() != DialogResult.Cancel)
            {
                CreateAttachment(ofdMain.FileName);  //upload the attachment
            }
            FillDataGrid(gridViewMain, strQuery_AllAttachments);  // refresh grid
        }
        private void CreateAttachment(string strFile)
        {
            SqlDataAdapter objAdapter = new SqlDataAdapter(strQuery_AllAttachments_AllFields, objConn);
            objAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SqlCommandBuilder objCmdBuilder = new SqlCommandBuilder(objAdapter);
            DataTable objTable = new DataTable();
            FileStream objFileStream = new FileStream(strFile, FileMode.Open, FileAccess.Read);
            int intLength = Convert.ToInt32(objFileStream.Length);
            byte[] objData;
            objData = new byte[intLength];
            DataRow objRow;
            string[] strPath = strFile.Split(Convert.ToChar(@"\"));
            objAdapter.Fill(objTable);
            objFileStream.Read(objData, 0, intLength);
            objFileStream.Close();
            objRow = objTable.NewRow();
            objRow["fileName"] = strPath[strPath.Length - 1]; //clip the full path - we just want last part!
            objRow["fileSize"] = intLength / 1024; // KB instead of bytes
            objRow["attachment"] = objData;  //our file
            objTable.Rows.Add(objRow); //add our new record
            objAdapter.Update(objTable);
        }
        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            SaveAttachment(sfdMain, gridViewMain);
            FillDataGrid(gridViewMain, strQuery_AllAttachments);  // refresh grid
        }
        private void SaveAttachment(SaveFileDialog objSfd, DataGridView objGrid)
        {
            string strId = objGrid.SelectedRows[0].Cells["id"].Value.ToString();
            string fileName = objGrid.SelectedRows[0].Cells["fileName"].Value.ToString();
            if (!string.IsNullOrEmpty(fileName))
            {
                
                SqlCommand sqlCmd = new SqlCommand(strQuery_GetAttachmentById, objConn);
                sqlCmd.Parameters.AddWithValue("@attachId", strId);
                SqlDataAdapter objAdapter = new SqlDataAdapter(sqlCmd);
                DataTable objTable = new DataTable();
                DataRow objRow;
                objAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                SqlCommandBuilder sqlCmdBuilder = new SqlCommandBuilder(objAdapter);
                objAdapter.Fill(objTable);
                objRow = objTable.Rows[0];
                
                byte[] objData;
                objData = (byte[])objRow["attachment"];
                FileInfo fileInfo = new FileInfo(fileName);
                string fileExtension = fileInfo.Extension;
                //Set Save dialog properties
                objSfd.Filter = "Files (*" + fileExtension + ")|*" + fileExtension;
                objSfd.Title = "Save File as";
                objSfd.CheckPathExists = true;
                objSfd.FileName = fileName;
                if (objSfd.ShowDialog() == DialogResult.OK)
                {
                    string strFileToSave = objSfd.FileName;
                    FileStream objFileStream = new FileStream(strFileToSave, FileMode.Create, FileAccess.Write);
                    objFileStream.Write(objData, 0, objData.Length);
                    objFileStream.Close();
                }
            }
        }
