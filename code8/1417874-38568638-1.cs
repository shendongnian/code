        public void BPForm_ItemEvent_Load(String FormUID, ref SAPbouiCOM.ItemEvent pVal, ref bool BubbleEvent)
        {            
            SAPbouiCOM.Button obutton;
            SAPbouiCOM.Item oitem;
            SAPbouiCOM.Item oNewItem;
            SAPbouiCOM.Folder oFolderItem;
            SAPbouiCOM.Form oform;
            oform = HandleSAPB1.SBO_Application.Forms.Item(pVal.FormUID);
            oNewItem = oform.Items.Add("my_tab", SAPbouiCOM.BoFormItemTypes.it_FOLDER);
            oitem = oform.Items.Item("9"); // UI element in the system form to use for positional reference 
            oNewItem.Top = oitem.Top;
            oNewItem.Height = oitem.Height;
            oNewItem.Left = oitem.Left + oitem.Width;
            oFolderItem = oNewItem.Specific;
            oFolderItem.Caption = "My Tab's Name";
            oFolderItem.GroupWith("9");
            oform.PaneLevel = 1;
            UIManager.AddTabElements(oform); // my custom class that adds UI controls to the tab
        }
