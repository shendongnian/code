    string input = @"Injection protection test:
    <script> alert('fail'); 
    </script> 
    <asp:SqlDataSource runat="server"></asp:SqlDataSource>
    <%= Server.Rewrite( ....) %>"
    
    string[] shouldNotContain=
    {
        "sql",
        "<%=",
        "script"
    };
    
    if(shouldNotContain.Any(input.Contains)
    {
       //The imput contains one or more of the keywords above
    }
    else
    {
        //The string is fine
    }
