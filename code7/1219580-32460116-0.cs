    <asp:TextBox runat="server" ID="UserName" />                            
    <asp:CustomValidator ID="CustomValidator1" runat="server" 
    ControlToValidate="UserName" ></asp:CustomValidator>
    protected void ValidateUser(object source, ServerValidateEventArgs args)
            {
                Regex regx = new Regex("^[a-zA-Z0-9]{6,}$");
                Regex regx2 = new Regex("^[a-zA-Z0-9]{6,}$");
                if (regx.IsMatch(UserName.Text) == false)
                {
                    CustomValidator1.ErrorMessage = "error message";
                    args.IsValid = false;
                }
                else if(regx2.IsMatch(UserName.Text) == false) 
                {
                    CustomValidator1.ErrorMessage = "second error message";
                    args.IsValid = false;
                }
              else
               {args.IsValid = true;}
           }
