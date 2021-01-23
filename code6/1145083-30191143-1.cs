    public static void MsgBox(string title, Page page)
            {
                AjaxControlToolkit.ModalPopupExtender ModalPopupExtender =
                    page.FindControl("ctl00$MainContent$MsgBoxModalPopupExtender") as AjaxControlToolkit.ModalPopupExtender;
                System.Web.UI.WebControls.Label Label =
                    page.FindControl("ctl00$MainContent$LabelMsgBox") as System.Web.UI.WebControls.Label;
    
                string message = "<b>" + title + "</b>";
               
                Label.Text = message;
                
                UpdatePanel UpdatePanel = page.FindControl("ctl00$MainContent$UpdatePanelMsgBox") as UpdatePanel;            
                UpdatePanel.Update();
                ModalPopupExtender.Show();                
                
            }
