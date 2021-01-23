    <%@ Application Language="C#" %>
    <%@ Import Namespace="System.Data" %>
    <%@ Import Namespace="System.Web.UI" %>
    
    <script RunAt="server">
    
        
    //here you can write your C# Code
    
     public void Page_Load(object sender, EventArgs e)
       {
          bool myBool = false;
          MyLabel.Text = myBool.ToString();  //works fine
          MyLabel.Text = MyProject.BusinessLogic.StatusManager.Get().ToString(); //does not work
       }
    
        
       
    </script>
