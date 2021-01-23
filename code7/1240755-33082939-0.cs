    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Text;
    using System.Web.UI.WebControls;
    namespace videoplayer
    {
        public partial class VideoPage : System.Web.UI.Page
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            protected void Page_Load(object sender, EventArgs e)
            {
                getdata();
            }
            private void getdata()
            {
                StringBuilder htmlBuilder = new StringBuilder();
                string a = string.Empty;
                string b = string.Empty;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Filename FROM VideoFile", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    htmlBuilder.AppendLine("<li data-address='local9' class='playlistNonSelected' data-type='local' data-mp4Path='../media/video/1/main/02.mp4' data-ogvPath='../media/video/1/main/02.ogv' data-webmPath='../media/video/1/main/02.webm' data-imagePath='../media/video/1/main/02.jpg' data-description='<span class='infoTitle'>Nulla mauris justo</span><br><br>Aenean egestas. Donec vel sapien ultrices lorem laoreet viverra. Curabitur molestie gravida nisi. Vivamus elementum scelerisque lectus. Etiam interdum, nisi vel adipiscing gravida, leo tortor placerat ipsum, a eleifend velit tortor id ligula. Etiam quis leo a velit mollis vestibulum. Morbi consequat, odio eget feugiat mollis, enim erat dignissim ipsum, eget vehicula sapien metus non massa. Aliquam aliquet sagittis ligula. Sed adipiscing sodales ipsum. Mauris orci ligula, commodo vitae, commodo in, tempor eu, urna. Etiam justo ipsum, gravida vitae, tristique sed, porttitor ac, ipsum. Maecenas elit lectus, elementum id, fermentum eget, accumsan ac, quam. Duis lacinia urna ac nisi. Cras bibendum. In hac habitasse platea dictumst. Morbi iaculis volutpat dui. Pellentesque non leo.;<a href='' target='_blank'>Link</a>'<div class='playlistThumb'><img class='thumb' src='../media/video/1/preview/02.jpg' width='120' height='68' alt=''/></div><div class='playlistInfo'><p><span class='playlistTitle'>Video title goes here</span><br><span class='playlistContent'>Commodo vitae, commodo in, tempor eu, urna. Etiam justo ipsum maecenas nec tellus.</span></p></div></li>");
                }
                con.Close();
                Literal lit = new Literal();
                lit.Text = htmlBuilder.ToString();
                PlaceHolder1.Controls.Add(lit);
            }
        }
    }
