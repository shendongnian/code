    using System.IO;
    
    string appPath = Path.GetDirectoryName(Application.Executable) + @"/student Images/";
    string imagename;
    
    //put this code below to load form.
    getimage();
    if(File.Exist(appPath + imagename)
    {
    PictureBox1.Image = Image.FromFile(appPath + imagename);
    }
    else
    {
    PictureBox1.Image = Properties.Resources.Image_notfound;
    }
    
    private void getimage()
    {
    MySqlConnection connect = new MySqlConnection(con);
    MySqlCommand cmd = new MySqlCommand("SELECT PictureName as 'pic' FROM userprofile where ID='" + datagrid.CurrentRow.Cells["ID"].ToString() + "'");
    cmd.CommandType = CommandType.Text;
    cmd.Connection = connect;
    connect.Open();
    Try
    {
    MySqlDataReader dr = cmd.ExecuteReader();
    while(dr.Read())
    {
    imagename = dr.GetString("pic");
    }
    dr.Close();
    }
    catch(Exception ee)
    {
    Console.WriteLine(ee.ToString());
    }
    finally
    {
    connect.Close();
    }
