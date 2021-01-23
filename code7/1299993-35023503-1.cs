    public static class MessageBox
    {
    public static void ShowMessage(string MessageText, Page MyPage)
        {     
                MyPage.ClientScript.RegisterStartupScript(MyPage.GetType(),
                "MessageBox", "alert('" + MessageText.Replace("'", "\'") + "');", true);
        }
    }
