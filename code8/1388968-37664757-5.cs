    public class DetailForm : Form
    {
         public DetailForm(string studentID)
         {
              InitializeComponent();
              // code that retrieves the student details knowing the studentID
              DataTable dt = GetStudentDetails(studentID);
              // code that sets the DetailForm controls with the student details
              if(dt.Rows.Count > 0)
              {
                  txtStudentName.Text = dt.Rows[0]["StudentName"].ToString();
                  ... and so on ....
              }
              ....
         }
         private DataTable GetStudentDetails(string studentID)
         {
             using(MySqlConnection conn = ConnectionService.getConnection())
             using(MySqlDataAdapter ada = new MySqlDataAdapter("select * from student where id_student = @id", conn))
             {
                 ada.SelectCommand.Parameters.Add("@id", MySqlDbType.VarChar).Value = studentID;
                 DataTable dt = new DataTable();
                 ada.Fill(dt);
                 return dt;
             }
        }
    }
