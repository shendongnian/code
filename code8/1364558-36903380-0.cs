            Microsoft.Office.Tools.Word.Document doc = Globals.Factory.GetVstoObject(ActiveDoc);
            foreach (ContentControl cc in ActiveDoc.ContentControls) {
                if (cc.Type == WdContentControlType.wdContentControlDropdownList) {
                    var dropList = doc.Controls.AddDropDownListContentControl("MyControl");
                    dropList.Tag = "MyControl";
                    dropList.Entering += (sender, args) => {
                        var that = (DropDownListContentControl) sender;
                        Debug.Print("Entering: " + that.Tag);
                    };
                }
            }
